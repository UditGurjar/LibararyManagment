using AutoMapper;
using Library.Models;
using Library.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DTO_Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookIssue, BookIssueDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<BookRating, BookRatingDto>().ReverseMap();
        }
    }
}
