using AutoMapper;
using NHibernateSample.Application.DTOs;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Api.Helpers;
public class MappingProfiles: Profile {
    public MappingProfiles() {
        CreateMap<BookDto, Book>();
        CreateMap<Book, BookDto>();
    }
}