using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa.extra
{
    interface ITransform
    {
        void rotate(Vector3 rotate);
        void translate(Vector3 translate);
        void scale(Vector3 scale);
    }
}
