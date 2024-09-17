using Castle.Core.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Modelli.Entities;
using Unicam.Paradigmi.Modelli.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void AddCategoria(Categoria categoria)
        {
            _categoriaRepository.Add(categoria);
            _categoriaRepository.Save();
        }

        public void DeleteCategoria(Categoria categoria)
        {
            _categoriaRepository.Delete(categoria);
            _categoriaRepository.Save();
        }

        public bool ValidateCategoria(Categoria categoria)
        {
            if (!(_categoriaRepository.ControlloCategoria(categoria).IsNullOrEmpty()))
            {
                return false;
            }
            return true;
        }

        public bool ValidateEliminazione(Categoria categoria)
        {
            if (!(_categoriaRepository.ControlloEliminazione(categoria).IsNullOrEmpty()))
            {
                return false;
            }
            return true;
        }
    }
}
