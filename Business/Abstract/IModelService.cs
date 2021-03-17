using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<List<Model>> GetAll();
        IDataResult<Model> GetById(int modelId);
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
    }
}
