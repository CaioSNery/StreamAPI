using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Stream.Models;

namespace StreamAPI.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Temporada, TemporadaResponseDTO>().ReverseMap();

            CreateMap<Temporada, TemporadaDTO>().ReverseMap();

            CreateMap<Episodio, EpisodioDTO>().ReverseMap();

            CreateMap<Episodio, EpisodioResponseDTO>().ReverseMap();

            
        }
    }
}