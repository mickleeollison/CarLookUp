using CarLookUp.Core.Constants;
using CarLookUp.Core.Models;
using CarLookUp.Core.Utilities;
using CarLookUp.Data.Repositories;
using CarLookUp.Data.Repositories.Interfaces;
using CarLookUp.Services.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace CarLookUp.Services.Services
{
    public class BodyTypeServices : IBodyTypeServices
    {
        private IBodyTypeRepository _bodyTypeRepository;

        public BodyTypeServices(IBodyTypeRepository bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }

        public ICollection<BodyTypeDTO> GetBodyTypes()
        {
            ICollection<BodyTypeDTO> list = (ICollection<BodyTypeDTO>)GlobalCachingProvider.Instance.GetItem(CacheKeys.BODYTYPES);
            if (list == null)
            {
                list = _bodyTypeRepository.GetBodyTypes<BodyTypeDTO>();
                GlobalCachingProvider.Instance.AddItem(CacheKeys.BODYTYPES, list);
            }
            return list;
        }
    }
}
