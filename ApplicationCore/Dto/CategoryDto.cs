using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto
{
    public sealed class CategoryDto
    {
        public int Id { get;}
        public string Name { get; }
        public string Description { get; }

        public CategoryDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
