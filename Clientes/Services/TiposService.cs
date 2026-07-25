using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Clientes.Models;
using Newtonsoft.Json;

namespace Clientes.Services
{
    public class TiposService
    {
        private static readonly object FileLock = new object();
        private readonly string _filePath;
        private readonly List<TipoCuenta> _defaultTypes = new List<TipoCuenta>
        {
            new TipoCuenta { Id = 1, Nombre = "Netflix" },
            new TipoCuenta { Id = 2, Nombre = "Flow" },
            new TipoCuenta { Id = 3, Nombre = "IPTV" },
            new TipoCuenta { Id = 4, Nombre = "DirecTVGo" },
            new TipoCuenta { Id = 5, Nombre = "AmazonPrime" },
            new TipoCuenta { Id = 6, Nombre = "Spotify" },
            new TipoCuenta { Id = 7, Nombre = "DisneyPlus" },
            new TipoCuenta { Id = 8, Nombre = "HBOMax" },
            new TipoCuenta { Id = 9, Nombre = "StarPlus" },
            new TipoCuenta { Id = 10, Nombre = "ParamountPlus" },
            new TipoCuenta { Id = 11, Nombre = "Telecentro" },
            new TipoCuenta { Id = 12, Nombre = "WOWPlus" },
            new TipoCuenta { Id = 13, Nombre = "WOWTV" },
            new TipoCuenta { Id = 14, Nombre = "Devex" }
        };

        public TiposService()
        {
            var dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            _filePath = Path.Combine(dataFolder, "tipos.json");
            EnsureFileExists();
        }

        public List<TipoCuenta> ObtenerTodos()
        {
            lock (FileLock)
            {
                return ReadTiposInternal().Where(x => x.Activo).OrderBy(x => x.Nombre).ToList();
            }
        }

        public TipoCuenta Buscar(int id)
        {
            lock (FileLock)
            {
                return ReadTiposInternal().FirstOrDefault(x => x.Id == id);
            }
        }

        public TipoCuenta BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return null;
            }

            lock (FileLock)
            {
                return ReadTiposInternal().FirstOrDefault(x =>
                    string.Equals(x.Nombre?.Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase) && x.Activo);
            }
        }

        public bool Agregar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            lock (FileLock)
            {
                var tipos = ReadTiposInternal();
                if (tipos.Any(x => string.Equals(x.Nombre?.Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }

                var nextId = tipos.Any() ? tipos.Max(x => x.Id) + 1 : 1;
                tipos.Add(new TipoCuenta
                {
                    Id = nextId,
                    Nombre = nombre.Trim(),
                    Activo = true
                });

                WriteTiposInternal(tipos);
                return true;
            }
        }

        public bool Renombrar(int id, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            lock (FileLock)
            {
                var tipos = ReadTiposInternal();
                var tipo = tipos.FirstOrDefault(x => x.Id == id);
                if (tipo == null)
                {
                    return false;
                }

                if (tipos.Any(x => x.Id != id && string.Equals(x.Nombre?.Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }

                tipo.Nombre = nombre.Trim();
                tipo.Activo = true;
                WriteTiposInternal(tipos);
                return true;
            }
        }

        public bool Eliminar(int id)
        {
            lock (FileLock)
            {
                var tipos = ReadTiposInternal();
                var tipo = tipos.FirstOrDefault(x => x.Id == id);
                if (tipo == null)
                {
                    return false;
                }

                tipos.Remove(tipo);
                WriteTiposInternal(tipos);
                return true;
            }
        }

        private void EnsureFileExists()
        {
            if (File.Exists(_filePath))
            {
                return;
            }

            WriteTiposInternal(_defaultTypes);
        }

        private List<TipoCuenta> ReadTiposInternal()
        {
            if (!File.Exists(_filePath))
            {
                return new List<TipoCuenta>(_defaultTypes);
            }

            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<TipoCuenta>(_defaultTypes);
            }

            try
            {
                var tipos = JsonConvert.DeserializeObject<List<TipoCuenta>>(json);
                return tipos == null || !tipos.Any() ? new List<TipoCuenta>(_defaultTypes) : tipos;
            }
            catch
            {
                return new List<TipoCuenta>(_defaultTypes);
            }
        }

        private void WriteTiposInternal(List<TipoCuenta> tipos)
        {
            var json = JsonConvert.SerializeObject(tipos.OrderBy(x => x.Id).ToList(), Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
