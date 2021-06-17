using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Models
{
    public enum MajorIndexType
    {
        Apple,
        Facebook,
        SP500
    }
    public class MajorIndex
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public MajorIndexType Type { get; set; }
    }
}
