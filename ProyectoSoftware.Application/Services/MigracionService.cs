using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.Interfaces.ICommands;

namespace ProyectoSoftware.Application.Services
{
    public class MigracionService: IMigracionService
    {
        private readonly IMigracionCommand _migracionCommand;

        public MigracionService(IMigracionCommand migracionCommand)
        {
            _migracionCommand = migracionCommand;
        }

        public void UpdateMigration()
        {
            _migracionCommand.MigrationUpdate();
        }
    }
}
