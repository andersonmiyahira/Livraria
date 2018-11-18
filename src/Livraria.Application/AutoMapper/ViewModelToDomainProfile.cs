using AutoMapper;
using Livraria.Application.AppService.Livros.ViewModels.Request;
using Livraria.Domain.Livros.Commands;
using System;

namespace Livraria.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<LivroViewModelRequest, AdicionarLivroCommand>();
            CreateMap<LivroViewModelRequest, AtualizarLivroCommand>();

        }
    }
}
