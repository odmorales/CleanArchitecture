﻿using CleanArchitecture.Domain;

namespace CleanArchitecture.Aplication.Contracts.Persistence
{
    public interface IVideoRepository: IAsyncRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);
        Task<IEnumerable<Video>> GetVideoByUserName(string userName);


    }
}
