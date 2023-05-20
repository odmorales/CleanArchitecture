using CleanArchitecture.Aplication.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;
using AutoMapper;
using CleanArchitecture.Aplication.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Aplication.Features.Directors.Commands.CreateDirector;
using CleanArchitecture.Aplication.Features.Streamers.Commands.UpdateStreamer;

namespace CleanArchitecture.Aplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
            CreateMap<UpdateStreamerCommand, Streamer>();
        } 
    }
}
