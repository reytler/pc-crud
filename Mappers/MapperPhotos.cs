using crudpcapi.DTOs;
using crudpcapi.Models;

namespace crudpcapi.Mappers
{
    public static class MapperPhotos
    {
        public static List<Photo> ConverterParaModel(this List<PhotoDTO> photos, long? sujeitoId=0)
        {
            return (from  photo in photos select new Photo { 
                Id = photo.Id,
                PhotoBytes = photo.Photobytes,        
                SujeitoId = (long)sujeitoId,                
            }).ToList();
        }
    }
}
