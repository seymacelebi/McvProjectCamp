using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public List<ImageFile> GetList()
        {
          return   _imageFileDal.List();
        }
    }
}
