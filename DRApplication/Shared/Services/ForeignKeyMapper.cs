using DRApplication.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Services
{
    public class ForeignKeyMapper<TEntity> where TEntity : class
    {
        private readonly MappingHelper _helper;

        public ForeignKeyMapper(MappingHelper helper)
        {
            _helper = helper;
        }

        /// <summary>
        /// Returns a Mapped DTO
        /// </summary>
        public IEnumerable<object> GetMappedClass()
        {
            var myList = _helper.VMList.ToList();

            //Get the TYPE of DTO
            var vmType = _helper.VMList.GetType().GetGenericArguments()[0];

            //Iterate through each of the entities in the Primary Entities (entity.MaintainerId needs to match _mapped.Id)
            foreach (var entity in _helper.PrimaryEntities)
            {
                //Create an instance of the ViewModel
                var viewModel = Activator.CreateInstance(vmType);

                // Iterate through the properties of the entity
                foreach (var property in entity.GetType().GetProperties())
                {
                    //Get the value of the property
                    var propertyValue = property.GetValue(entity, null);

                    // If the property name doesn't match the Foreign Key Name <-----Handles Properties besides the foreign key
                    if (property.Name != _helper.ForeignKeyName && viewModel is not null)
                    {
                        //These are NOT the properties besides the Foreign Key
                        //Iterate each of the properties of the class to map to
                        foreach (var vmProperty in viewModel.GetType().GetProperties())
                        {
                            //Check to find the ViewModel Property that matches the Entity Property
                            if (vmProperty.Name == property.Name)
                            {
                                //A match is made to the ENTITY property so set the value
                                vmProperty.SetValue(viewModel, propertyValue);
                            }
                        }
                    }
                    else
                    {
                        //property.Name = FOREIGN KEY NAME. Find the matching Primary Key in foreignEntities
                        foreach(var vmEntity in _helper.ForeignEntities)
                        {
                            //get the ID of the vmEntity
                            var vmEntityId = vmEntity.GetType().GetProperty("Id");

                            //get the Value of the ID
                            var vmEntityIdValue = vmEntityId.GetValue(vmEntity, null);

                            //check to see if the value matches the current property ID
                            if((int)vmEntityIdValue == (int)propertyValue)
                            {
                                //There is a match for the ID to Foreign ID for this Entity

                                //get the name property for the foreign table
                                var vmName = vmEntity.GetType().GetProperty("Name");

                                //get the value of the property
                                var vmValue = vmName.GetValue(vmEntity, null);

                                //Value is set!!!

                                var testValue = viewModel.GetType().GetProperty(_helper.ForeignColumnName);

                                //assign the value to the property
                                testValue.SetValue(viewModel, vmValue);
                            }
                        }

                    }
                    
                }
                myList.Add(viewModel);
            }
            return myList;
        }
    }
}
