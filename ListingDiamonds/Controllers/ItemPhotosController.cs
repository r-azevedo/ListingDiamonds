using Business.Repository.IRepository;
using ListingDiamonds.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ListingDiamonds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPhotosController : ControllerBase
    {
        private readonly IItemPhotosRepository _itemPhotosRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ItemPhotosController(IItemPhotosRepository itemPhotosRepository, IWebHostEnvironment webHostEnvironment)
        {
            _itemPhotosRepository = itemPhotosRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("GetItemPhotos")]
        public async Task<IEnumerable<ItemPhotosDTO>> GetItemPhotos(int? id = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                ItemPhotosDTO itemPhoto = await _itemPhotosRepository.GetItemPhotoById(id.Value);

                if (itemPhoto is not null)
                {
                    List<ItemPhotosDTO> itemPhotos = new List<ItemPhotosDTO>();
                    itemPhotos.Add(itemPhoto);
                    return itemPhotos;
                }
            }
            else
            {
                return await _itemPhotosRepository.GetlAllItemPhotos();
            }
            return null;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] FileModel image, int id)
        {
            if (image is not null && image.FormFile.Length > 0 && id > 0)
            {
                var fileToSave = _webHostEnvironment.WebRootPath + "\\Photos\\" + image.FileName;
                
                try
                {
                    var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\Photos";
                    if (!Directory.Exists(folderDirectory))
                    {
                        Directory.CreateDirectory(folderDirectory);
                    }

                    using (FileStream filestream = System.IO.File.Create(fileToSave))
                    {
                        await image.FormFile.CopyToAsync(filestream);
                        filestream.Flush();

                        ItemPhotosDTO itemPhotosDTO = await _itemPhotosRepository.GetItemPhotoById(id);
                        itemPhotosDTO.FileName = image.FileName;

                        var updatedItemPhoto = await _itemPhotosRepository.UpdateItemPhoto(id, itemPhotosDTO);

                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return null;
        }
        
    }
}
