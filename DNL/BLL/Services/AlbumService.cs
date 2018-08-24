using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AlbumService : Service<Album, AlbumViewModel>, IAlbumService
    {
        public AlbumService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Albums)
        {

        }
    }
}
