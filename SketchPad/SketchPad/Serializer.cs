using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SketchPad
{
    public static class Serializer
    {
        public static void Serialize( object obj, string path )
        {
            BinaryFormatter binForm = new BinaryFormatter( );

            using( Stream stream = new FileStream( path, FileMode.Create, FileAccess.Write, FileShare.None ) )
            {
                binForm.Serialize( stream, obj );
            }
        }

        public static object Deserialize( string path )
        {
            object result;

            BinaryFormatter binForm = new BinaryFormatter( );

            try
            {
                using( Stream stream = new FileStream( path, FileMode.Open, FileAccess.Read ) )
                {
                    result = binForm.Deserialize( stream );
                }
            }
            catch
            {
                return null;
            }

            return result;
        }
    }
}
