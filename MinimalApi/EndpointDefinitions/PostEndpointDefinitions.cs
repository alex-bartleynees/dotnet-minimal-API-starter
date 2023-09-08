using Application.Posts.Commands;
using Application.Posts.Queries;
using Ardalis.GuardClauses;
using Domain.Models;
using MediatR;
using MinimalApi.Abstractions;
using MinimalApi.Filters;

namespace MinimalApi.EndpointDefinitions
{
    public class PostEndpointDefinitions : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");

            posts.MapGet("/{id}", GetPostById)
            .WithName("GetPostById");
            posts.MapPost("/", CreatePost)
            .AddEndpointFilter<PostValidationFilter>();
            posts.MapGet("/", GetAllPosts);
            posts.MapPut("/{id}", UpdatePost)
            .AddEndpointFilter<PostValidationFilter>();
            posts.MapDelete("{id}", DeletePost);
        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var result = await mediator.Send(new GetPostById(id));
            return TypedResults.Ok(result);
        }

        private async Task<IResult> CreatePost(IMediator mediator, Post post)
        {
            var command = new CreatePost(post.Content);
            var result = await mediator.Send(command);
            return Results.CreatedAtRoute("GetPostById", new { result.Id }, result);
        }

        private async Task<IResult> GetAllPosts(IMediator mediator)
        {
            var result = await mediator.Send(new GetAllPosts());
            return TypedResults.Ok(result);
        }

        private async Task<IResult> UpdatePost(IMediator mediator, Post post, int id)
        {
            var command = new UpdatePost(id, post.Content);
            var result = await mediator.Send(command);
            return TypedResults.Ok(result);
        }

        private async Task<IResult> DeletePost(IMediator mediator, int id)
        {
            var command = new DeletePost(id);
            await mediator.Send(command);
            return TypedResults.NoContent();
        }
    }
}