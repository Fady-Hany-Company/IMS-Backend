using IMS.Application.DTOs.AuthorsDTO.CreateAuthor;

namespace IMS.Application.Features.Authors.CreateAuthor
{
    using MediatR;

    public record AddAuthorCommand(AddAuthorRequestDto RequestDto) : IRequest<int>;

}
