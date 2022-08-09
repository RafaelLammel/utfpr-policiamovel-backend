﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UTFPR.PoliciaMovel.API.Filters
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
       public void Apply(OpenApiOperation operation, OperationFilterContext context)
       {
           // Get Authorize attribute
           if (context.MethodInfo.DeclaringType == null) return;
           var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
               .Union(context.MethodInfo.GetCustomAttributes(true))
               .OfType<AuthorizeAttribute>();

           var authorizeAttributes = attributes as AuthorizeAttribute[] ?? attributes.ToArray();
           if (authorizeAttributes.Any())
           {
               var attr = authorizeAttributes.ToList()[0];

               // Add what should be show inside the security section
               IList<string> securityInfos = new List<string>();
               securityInfos.Add($"{nameof(AuthorizeAttribute.Policy)}:{attr.Policy}");
               securityInfos.Add($"{nameof(AuthorizeAttribute.Roles)}:{attr.Roles}");
               securityInfos.Add($"{nameof(AuthorizeAttribute.AuthenticationSchemes)}:{attr.AuthenticationSchemes}");

               operation.Security = attr.AuthenticationSchemes switch
               {
                   "Basic" => new List<OpenApiSecurityRequirement>()
                   {
                       new OpenApiSecurityRequirement()
                       {
                           {
                               new OpenApiSecurityScheme
                               {
                                   Reference = new OpenApiReference
                                   {
                                       Id =
                                           "basic", // Must fit the defined Id of SecurityDefinition in global configuration
                                       Type = ReferenceType.SecurityScheme,
                                   }
                               },
                               securityInfos
                           }
                       }
                   },
                   _ => new List<OpenApiSecurityRequirement>()
                   {
                       new OpenApiSecurityRequirement()
                       {
                           {
                               new OpenApiSecurityScheme
                               {
                                   Reference = new OpenApiReference
                                   {
                                       Id =
                                           "bearer", // Must fit the defined Id of SecurityDefinition in global configuration
                                       Type = ReferenceType.SecurityScheme
                                   }
                               },
                               securityInfos
                           }
                       }
                   }
               };
           }
           else
           {
               operation.Security.Clear();
           }
       }
    }
}