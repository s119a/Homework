﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApp
{
    public class Clients : IComparable
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Clients(string name)
        {
            Id = Guid.NewGuid().ToString();
            this.Name = name;
        }

        //重写Equals()函数
        public override bool Equals(object obj)
        {
            Clients client = obj as Clients;
            return client != null && this.Name == client.Name;
        }

        //重写GetHashCode()函数
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        //CompareTo()函数
        public int CompareTo(object obj)
        {
            Clients client = obj as Clients;
            if (client == null)
            {
                throw new System.ArgumentException();
            }
            return this.Name.CompareTo(client.Name);
        }

        //重写ToString()函数
        public override string ToString()
        {
            return Name;
        }


    }
}
