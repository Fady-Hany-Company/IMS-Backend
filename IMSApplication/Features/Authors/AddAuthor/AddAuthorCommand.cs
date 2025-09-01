namespace IMS.Application.Features.Authors.CreateAuthor
{
    using MediatR;

    public record AddAuthorCommand(
        string Name,
        string? Bio
        ) : IRequest<int>;

}
