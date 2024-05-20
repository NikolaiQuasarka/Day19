using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    public static class Reflector
    {
        public static bool WriteTextFIle(string path, string className)
        {
            if (File.Exists(path) & Type.GetType(className) != null)
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                         sw.WriteLine($"Имя класса:{className}; \n\nПубличные методы:{string.Join(' ', PublicMethods(Type.GetType(className)))}; \nПоля и свойства: {string.Join(' ', GetFieldsAndPropertys(Type.GetType(className)))}; \nИнтерфейсы: {string.Join(' ', GetInterfaces(Type.GetType(className)))}");
                        return true;
                    }
                }
            else return false;
        }

        public static string[] PublicMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            string[] names = new string[methods.Length];
            for (int i = 0; i < methods.Length; i++)
            {
                names[i] = methods[i].Name;
            }
            return names;
        }

        public static List<string> GetFieldsAndPropertys(Type type)
        {
            List<string> FieldsAndPropertys = new List<string>();
            foreach (FieldInfo field in type.GetFields())
            {
                FieldsAndPropertys.Add(field.Name);
            }
            foreach (PropertyInfo property in type.GetProperties())
            {
                FieldsAndPropertys.Add(property.Name);
            }
            return FieldsAndPropertys;
        }

        public static string[] GetInterfaces(Type type)
        {
            string[] interfaces = new string[type.GetInterfaces().Length];
            for (int i = 0; i < interfaces.Length; i++)
            {
                interfaces[i] = type.GetInterfaces()[i].Name;
            }
            return interfaces;
        }

        public static List<MethodInfo> GetMethodsWithT(Type mainType, Type findingByType)
        {
            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (MethodInfo method in mainType.GetMethods())
            {
                ParameterInfo[] parameters = method.GetParameters();
                foreach (ParameterInfo param in parameters)
                {
                    if (param.ParameterType == findingByType)
                    {
                        methods.Add(method);
                        break;
                    }
                }
            }
            return methods;
        }

        public static object InvokeMethod(Type className, string methodName)
        {
            MethodInfo classMethod = null;
            foreach (MethodInfo method in className.GetMethods())
            {
                if (method.Name == methodName)
                {
                    classMethod = method;

                }

            }
            if (classMethod == null)
                return false;
            else
            {
                //classMethod.Invoke(this, new object[] { });
                return true;
            }
        }
    }
}