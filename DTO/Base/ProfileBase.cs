using AutoMapper;
using Data.Interface;
using DTO.Interface;

namespace DTO.Base;
public abstract class ProfileBase<T, U>: Profile where T: IDto where U: IEntity
{

    public ProfileBase()
    {
        CreateMapping();
    }

    public virtual void CreateMapping()
    {
        CreateMap<T, U>().ReverseMap();
    }
}
