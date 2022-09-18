using System;
using System.IO;
using System.Threading.Tasks;

namespace CodingChallenge.Services.Contracts
{
    public interface IImagePickerService
    {
        Task<string> PickImageAsync();
    }
}

