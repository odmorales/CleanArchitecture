using MediatR;

namespace CleanArchitecture.Aplication.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommand : IRequest
    {
        public int Id { get; set; }

    }
}
