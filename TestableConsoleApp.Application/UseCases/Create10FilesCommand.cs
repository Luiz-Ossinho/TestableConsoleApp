using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestableConsoleApp.Shared.Interfaces.FileGeneration.Services;
using TestableConsoleApp.Shared.Interfaces.FileStorage.Repositories;
using TestableConsoleApp.Shared.Interfaces.Shared;
using TestableConsoleApp.Shared.Models.Application;
using TestableConsoleApp.Shared.Models.Shared;

namespace TestableConsoleApp.Application.UseCases
{
    public class Create10FilesCommand : ICommand { }
    public class Create10FilesCommandHandler : ICommandHandler<Create10FilesCommand>
    {
        private readonly IFileGenerator _fileGeneratorService;
        private readonly IFileStorageRepository _fileStorageRepository;

        public Create10FilesCommandHandler(IFileGenerator fileGeneratorService, IFileStorageRepository fileStorageRepository)
        {
            _fileGeneratorService = fileGeneratorService;
            _fileStorageRepository = fileStorageRepository;
        }
        public async Task<IResult<Nothing>> Handle(Create10FilesCommand command)
        {
            var result = new ApplicationResult();
            var streamArquivos = new List<Stream>();
            //Cria 10 stream de arquivos
            try
            {
                for (int i = 10 - 1; i >= 0; i--)
                    streamArquivos.Add(await _fileGeneratorService.GenerateFile());
            }
            catch (System.Exception)
            {
                return result.WithError("Nao consegui gerar os arquivos");
            }


            try
            {
                //Salva os 10 arquivos
                //Erro intencional
                for (int i = 10 - 1; i >= 0; i--)
                    await _fileStorageRepository.SaveStreamAsFile(streamArquivos[i]);
            }
            catch (System.Exception)
            {
                return result.WithError("Nao consegui salvar os arquivos");
            }

            return result.WithSuccess();
        }
    }
}
