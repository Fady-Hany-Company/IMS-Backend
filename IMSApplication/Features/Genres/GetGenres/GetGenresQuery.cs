using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.GenresDTO.GetGenres;
using MediatR;

namespace IMS.Application.Features.Genres.GetGenres
{
    public record GetGenresQuery() : IRequest<List<GetGenresResponseDto>>;
}
