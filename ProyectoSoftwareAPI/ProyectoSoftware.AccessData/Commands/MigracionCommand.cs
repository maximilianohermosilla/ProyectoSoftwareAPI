﻿using ProyectoSoftware.Domain.ICommands;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSoftware.AccessData.Commands
{
    public class MigracionCommand: IMigracionCommand
    {
        private ProyectoSoftwareContext _context;

        public MigracionCommand(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public void MigrationUpdate()
        {
            _context.Database.Migrate();          
        }
    }
}
