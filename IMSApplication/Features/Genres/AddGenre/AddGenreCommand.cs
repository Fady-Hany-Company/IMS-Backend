using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.GenresDTO.CreateGenre;
using MediatR;

namespace IMS.Application.Features.Genres.CreateGenre
{
    public record AddGenreCommand(AddGenreRequestDto RequestDto) : IRequest<int>;
}
