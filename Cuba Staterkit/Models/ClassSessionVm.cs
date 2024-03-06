using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Cuba_Staterkit.Data;

namespace Cuba_Staterkit.Models
{
    public class ClassSessionVm
    {
        public string QuizName { get; set; }
        public string HomeworkName { get; set; }
        public string SessionName { get; set;}
        public int SessionNumber { get; set;}
        public Quiz Quiz { get; set;}
        public HomeWork HomeWork { get; set;}
        public Session Session { get; set;}
    }

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    //public class UniqueCombinationAttribute : ValidationAttribute
    //{
    //    private readonly string[] _propertyNames;
    //    private readonly Context context;

    //    public UniqueCombinationAttribute(Context Context, params string[] propertyNames)
    //    {
    //        _propertyNames = propertyNames;
    //        context = Context;
    //    }

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value != null)
    //        {
    //            var properties = new List<string>();
    //            foreach (var propertyName in _propertyNames)
    //            {
    //                var property = validationContext.ObjectType.GetProperty(propertyName);
    //                if (property != null)
    //                {
    //                    var propertyValue = property.GetValue(validationContext.ObjectInstance, null);
    //                    properties.Add(propertyValue?.ToString());
    //                }
    //                else
    //                {
    //                    return new ValidationResult($"Unknown property: {propertyName}");
    //                }
    //            }

    //            // Check for uniqueness of the combination
    //            var dbContext = (Context)validationContext.GetService(typeof(Context));
    //            var entity = dbContext.Set(validationContext.ObjectType).Find(properties.ToArray());
    //            if (entity != null)
    //            {
    //                return new ValidationResult(ErrorMessage ?? "The combination of values is not unique.");
    //            }
    //        }

    //        return ValidationResult.Success;
    //    }
    //}
}