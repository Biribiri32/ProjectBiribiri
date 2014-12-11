using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIKUEngine.Interfaces
{
    public interface IDrawable
    {
        void LoadContent();

        void Update();

        void Draw();
    }
}
