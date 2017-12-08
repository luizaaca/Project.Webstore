using System.Collections.Generic;
using AutoMapper;
using Project.Webstore.Model.ProductAttributes.Interfaces;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.Services.Mapping
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup ToRefinementGroup(this IEnumerable<IProductAttribute> productAttributes, RefinementGroupings refinementGroupType)
        {
            var refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };

            refinementGroup.Refinements = Mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>(productAttributes);

            return refinementGroup;
        }
    }
}
