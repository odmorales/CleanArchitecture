using AutoFixture;
using CleanArchitecture.Aplication.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static Mock<VideoRepository> GetVideoRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var videos = fixture.CreateMany<Video>().ToList();

            videos.Add(fixture.Build<Video>()
                .With(tr => tr.CreatedBy, "vaxidrez")
                .Create()
                );

            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;

            var stramerDbContextFake = new StreamerDbContext(options);
            stramerDbContextFake.Videos!.AddRange(videos);
            stramerDbContextFake.SaveChanges();

            var mockRepository = new Mock<VideoRepository>(stramerDbContextFake);

            return mockRepository;
        }
    }
}
