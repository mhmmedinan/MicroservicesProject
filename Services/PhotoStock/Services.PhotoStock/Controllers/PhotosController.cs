﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.PhotoStock.Dtos;
using Course.Shared.Utilities.ControllerBases;
using Course.Shared.Utilities.Dtos;

namespace Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo,CancellationToken cancellationToken)
        {
            if (photo!=null && photo.Length>0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/photos", photo.FileName);

                using var stream = new FileStream(path,FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);

                var returnPath =  photo.FileName;

                PhotoDto photoDto = new() {Url = returnPath};
                return CreateActionResultInstance(Response<PhotoDto>.Success(photoDto, 200));

            }

            return CreateActionResultInstance(Response<PhotoDto>.Fail("photo is empty", 400));
        }
        
        [HttpDelete]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/photos",photoUrl);
            if (!System.IO.File.Exists(path))
            {
                return BadRequest("Photo not found");
            }

            System.IO.File.Delete(path);

            return Ok();
        }
    }
}
