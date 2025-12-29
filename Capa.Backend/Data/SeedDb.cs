using Capa.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Capa.Backend.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCarrerasAsync();
            await CheckLineasInvestigacionAsync();
            await CheckDocentesAsync();
            await CheckDocenteLineasAsync();
            await CheckEstudiantesAsync();
            await CheckProyectosAsync();
            await CheckHistorialTutoriasAsync();
        }

        private async Task CheckCarrerasAsync()
        {
            if (_context.Carreras.Any()) return;
            _context.Carreras.AddRange(
                new Carrera { Nombre = "Ing. Sistemas" },
                new Carrera { Nombre = "Ing. Comercial" },
                new Carrera { Nombre = "Ing. Civil" }
            );
            await _context.SaveChangesAsync();
        }

        private async Task CheckLineasInvestigacionAsync()
        {
            if (_context.LineasInvestigacion.Any()) return;
            _context.LineasInvestigacion.AddRange(
                new LineaInvestigacion { Nombre = "Inteligencia Artificial", Descripcion = "Aprendizaje automático, PLN, visión por computadora." },
                new LineaInvestigacion { Nombre = "Ciencia de Datos", Descripcion = "Analítica, minería de datos, visualización." },
                new LineaInvestigacion { Nombre = "Ingeniería de Software", Descripcion = "Arquitectura, calidad, metodologías ágiles." },
                new LineaInvestigacion { Nombre = "Ciberseguridad", Descripcion = "Seguridad de la información, auditoría, riesgos." },
                new LineaInvestigacion { Nombre = "Sistemas Empresariales", Descripcion = "ERP, procesos, finanzas." }
            );
            await _context.SaveChangesAsync();
        }

        private async Task CheckDocentesAsync()
        {
            if (_context.Docentes.Any()) return;

            await AddDocenteAsync("21222321", "Fernando", "Apaza Luna", "fernando@yopmail.com",
                @"Ingeniero de Sistemas con amplia experiencia en desarrollo de software empresarial, bases de datos relacionales, arquitectura de sistemas y proyectos de transformación digital. Ha participado como tutor en proyectos relacionados con sistemas académicos, plataformas web, sistemas de control administrativo y aplicaciones con inteligencia artificial. Especialista en .NET, SQL Server, APIs REST y análisis de requerimientos.",
                "Ing. Sistemas");

            await AddDocenteAsync("45875212", "Lidia", "Mamani Mara", "lidia@yopmail.com",
                @"Ingeniera de Sistemas con enfoque en ciencia de datos, machine learning y análisis predictivo. Experiencia en proyectos de minería de datos, visualización de información y aplicaciones académicas con modelos de aprendizaje automático. Conocimientos en Python, Scikit-Learn, análisis estadístico y procesamiento de lenguaje natural.",
                "Ing. Sistemas");

            await AddDocenteAsync("88745212", "Marcos", "Pedraza Campos", "pedraza@yopmail.com",
                @"Ingeniero de Sistemas con especialidad en desarrollo web full stack, aplicaciones móviles y arquitectura de software. Tutor de proyectos relacionados con sistemas de gestión, plataformas educativas, aplicaciones móviles y comercio electrónico. Experiencia en .NET, JavaScript, React, bases de datos SQL y diseño de sistemas distribuidos.",
                "Ing. Sistemas");

            await AddDocenteAsync("15874521", "Marcelo", "Aponte Chavez", "aponte@yopmail.com",
                @"Ingeniero Comercial con experiencia en sistemas de información empresarial, gestión de procesos, análisis financiero y control administrativo. Ha asesorado proyectos de grado relacionados con sistemas de ventas, gestión de inventarios, contabilidad y administración de empresas. Especialista en análisis de costos, planificación estratégica y sistemas ERP.",
                "Ing. Comercial");

            await AddDocenteAsync("33445566", "Ana", "Quispe Rojas", "anaq@yopmail.com",
                @"Ingeniera de Sistemas con especialización en ciberseguridad y seguridad informática. Experiencia en auditoría de sistemas, gestión de riesgos tecnológicos y protección de datos. Ha sido tutora en proyectos de seguridad de la información, análisis de vulnerabilidades y desarrollo de sistemas seguros para instituciones académicas y empresariales.",
                "Ing. Sistemas");

            await AddDocenteAsync("55667788", "Carlos", "Rivera Choque", "carlosr@yopmail.com",
                @"Ingeniero de Sistemas con experiencia en inteligencia artificial aplicada, visión por computadora y procesamiento de imágenes. Ha tutorizado proyectos de reconocimiento facial, detección de objetos y sistemas inteligentes para automatización de procesos.",
                "Ing. Sistemas");

            await AddDocenteAsync("77889900", "Verónica", "Salazar Pinto", "veronica@yopmail.com",
                @"Ingeniera de Sistemas con enfoque en ingeniería de software, calidad de sistemas y metodologías ágiles. Experiencia en dirección de proyectos, pruebas de software, gestión de requerimientos y arquitectura de aplicaciones empresariales.",
                "Ing. Sistemas");

            await AddDocenteAsync("99001122", "Jorge", "Medina Flores", "jorge@yopmail.com",
                @"Ingeniero de Sistemas con especialidad en ciencia de datos, big data y analítica avanzada. Ha desarrollado y tutorizado proyectos de análisis de grandes volúmenes de datos, sistemas de recomendación y modelos predictivos para toma de decisiones.",
                "Ing. Sistemas");

            await _context.SaveChangesAsync();
        }

        private async Task CheckDocenteLineasAsync()
        {
            if (_context.DocenteLineasInvestigacion.Any()) return;

            var ia = await _context.LineasInvestigacion.FirstAsync(x => x.Nombre == "Inteligencia Artificial");
            var data = await _context.LineasInvestigacion.FirstAsync(x => x.Nombre == "Ciencia de Datos");
            var soft = await _context.LineasInvestigacion.FirstAsync(x => x.Nombre == "Ingeniería de Software");
            var cyber = await _context.LineasInvestigacion.FirstAsync(x => x.Nombre == "Ciberseguridad");
            var erp = await _context.LineasInvestigacion.FirstAsync(x => x.Nombre == "Sistemas Empresariales");

            var fernando = await _context.Docentes.FirstAsync(x => x.Nombres == "Fernando");
            var lidia = await _context.Docentes.FirstAsync(x => x.Nombres == "Lidia");
            var marcos = await _context.Docentes.FirstAsync(x => x.Nombres == "Marcos");
            var marcelo = await _context.Docentes.FirstAsync(x => x.Nombres == "Marcelo");
            var ana = await _context.Docentes.FirstAsync(x => x.Nombres == "Ana");
            var carlos = await _context.Docentes.FirstAsync(x => x.Nombres == "Carlos");
            var veronica = await _context.Docentes.FirstAsync(x => x.Nombres == "Verónica");
            var jorge = await _context.Docentes.FirstAsync(x => x.Nombres == "Jorge");

            _context.DocenteLineasInvestigacion.AddRange(
                new DocenteLineaInvestigacion { Docente = fernando, LineaInvestigacion = ia },
                new DocenteLineaInvestigacion { Docente = fernando, LineaInvestigacion = soft },
                new DocenteLineaInvestigacion { Docente = lidia, LineaInvestigacion = data },
                new DocenteLineaInvestigacion { Docente = marcos, LineaInvestigacion = soft },
                new DocenteLineaInvestigacion { Docente = marcelo, LineaInvestigacion = erp },
                new DocenteLineaInvestigacion { Docente = ana, LineaInvestigacion = cyber },
                new DocenteLineaInvestigacion { Docente = carlos, LineaInvestigacion = ia },
                new DocenteLineaInvestigacion { Docente = veronica, LineaInvestigacion = soft },
                new DocenteLineaInvestigacion { Docente = jorge, LineaInvestigacion = data }
            );

            await _context.SaveChangesAsync();
        }

        private async Task CheckEstudiantesAsync()
        {
            if (_context.Estudiantes.Any()) return;

            await AddEstudianteAsync("65652544", "Ever", "Muchairo Lazo", "muchairo@yopmail.com", "R298-4", "Ing. Sistemas");
            await AddEstudianteAsync("11255712", "Waldo", "Saenz Pilco", "waldo@yopmail.com", "R299-2", "Ing. Sistemas");
            await AddEstudianteAsync("45888544", "Felipe", "Montes Paz", "felipem@yopmail.com", "R300-1", "Ing. Sistemas");
            await AddEstudianteAsync("20125485", "Pablo", "Quette Lara", "pablol@yopmail.com", "R300-2", "Ing. Sistemas");
            await AddEstudianteAsync("10111213", "Jorge", "Mamanta Duri", "jorged@yopmail.com", "R300-3", "Ing. Sistemas");
            await AddEstudianteAsync("20212223", "Mariela", "Daza Surita", "marielad@yopmail.com", "R300-4", "Ing. Sistemas");
            await AddEstudianteAsync("22745225", "Milton", "Yujra Pally", "milton@yopmail.com", "R300-5", "Ing. Sistemas");
            await AddEstudianteAsync("21874588", "Dario", "Miranda Lino", "dario@yopmail.com", "R450-1", "Ing. Comercial");

            await _context.SaveChangesAsync();
        }

        private async Task CheckProyectosAsync()
        {
            if (_context.ProyectoGrados.Any()) return;

            var estudiantes = await _context.Estudiantes.ToListAsync();
            var docentes = await _context.Docentes.ToListAsync();

            AddProyecto(estudiantes.First(e => e.Nombres == "Ever"), docentes.First(d => d.Nombres == "Fernando"),
                "Sistema de gestión académica con inteligencia artificial",
                "Desarrollo de un sistema web para automatizar procesos académicos mediante algoritmos de inteligencia artificial, incluyendo análisis de rendimiento, predicción de deserción estudiantil y recomendación automática de tutorías.",
                "2024");

            AddProyecto(estudiantes.First(e => e.Nombres == "Waldo"), docentes.First(d => d.Nombres == "Lidia"),
                "Plataforma de análisis predictivo del rendimiento estudiantil",
                "Implementación de una plataforma basada en machine learning que analice el comportamiento académico y genere modelos predictivos.",
                "2024");

            AddProyecto(estudiantes.First(e => e.Nombres == "Felipe"), docentes.First(d => d.Nombres == "Carlos"),
                "Sistema de reconocimiento facial para control de acceso universitario",
                "Sistema inteligente con visión por computadora para identificar personas y controlar accesos.",
                "2024");

            AddProyecto(estudiantes.First(e => e.Nombres == "Pablo"), docentes.First(d => d.Nombres == "Jorge"),
                "Sistema de análisis de grandes volúmenes de datos para toma de decisiones",
                "Plataforma de big data orientada al procesamiento y visualización para apoyo estratégico.",
                "2024");

            AddProyecto(estudiantes.First(e => e.Nombres == "Jorge"), docentes.First(d => d.Nombres == "Ana"),
                "Sistema de detección de vulnerabilidades en redes académicas",
                "Herramienta de seguridad para análisis de vulnerabilidades y protección de datos.",
                "2023");

            AddProyecto(estudiantes.First(e => e.Nombres == "Mariela"), docentes.First(d => d.Nombres == "Marcos"),
                "Aplicación móvil para gestión de proyectos colaborativos",
                "Aplicación multiplataforma para planificación, asignación de tareas y control de avances.",
                "2023");

            AddProyecto(estudiantes.First(e => e.Nombres == "Milton"), docentes.First(d => d.Nombres == "Verónica"),
                "Sistema de control de calidad de software basado en métricas",
                "Evaluación de calidad mediante métricas, pruebas automatizadas y seguimiento de defectos.",
                "2023");

            AddProyecto(estudiantes.First(e => e.Nombres == "Dario"), docentes.First(d => d.Nombres == "Marcelo"),
                "Sistema integrado de gestión empresarial para PYMES",
                "Desarrollo de un sistema ERP para control de ventas, inventarios y contabilidad.",
                "2023");

            await _context.SaveChangesAsync();
        }

        private async Task CheckHistorialTutoriasAsync()
        {
            if (_context.HistorialTutorias.Any()) return;

            var fernando = await _context.Docentes.FirstAsync(x => x.Nombres == "Fernando");
            var lidia = await _context.Docentes.FirstAsync(x => x.Nombres == "Lidia");
            var carlos = await _context.Docentes.FirstAsync(x => x.Nombres == "Carlos");
            var jorge = await _context.Docentes.FirstAsync(x => x.Nombres == "Jorge");

            _context.HistorialTutorias.AddRange(
                new HistorialTutoria { Docente = fernando, Tema = "Sistema académico inteligente", Carrera = "Ing. Sistemas", Resultado = "Aprobado", Fecha = DateTime.Now.AddYears(-1) },
                new HistorialTutoria { Docente = fernando, Tema = "Plataforma educativa con IA", Carrera = "Ing. Sistemas", Resultado = "Aprobado", Fecha = DateTime.Now.AddYears(-2) },
                new HistorialTutoria { Docente = lidia, Tema = "Modelo predictivo académico", Carrera = "Ing. Sistemas", Resultado = "Aprobado", Fecha = DateTime.Now.AddYears(-1) },
                new HistorialTutoria { Docente = carlos, Tema = "Reconocimiento facial institucional", Carrera = "Ing. Sistemas", Resultado = "Aprobado", Fecha = DateTime.Now.AddYears(-1) },
                new HistorialTutoria { Docente = jorge, Tema = "Analítica big data universitaria", Carrera = "Ing. Sistemas", Resultado = "Aprobado", Fecha = DateTime.Now.AddYears(-1) }
            );

            await _context.SaveChangesAsync();
        }

        private async Task AddDocenteAsync(string nroCi, string nombres, string apellidos, string correo, string perfil, string carrera)
        {
            var carrer = await _context.Carreras.FirstAsync(x => x.Nombre == carrera);
            _context.Docentes.Add(new Docente { NroCi = nroCi, Nombres = nombres, Apellidos = apellidos, Correo = correo, ResumenPerfil = perfil, Carrera = carrer });
        }

        private async Task AddEstudianteAsync(string nroCi, string nombres, string apellidos, string correo, string codigo, string carrera)
        {
            var carrer = await _context.Carreras.FirstAsync(x => x.Nombre == carrera);
            _context.Estudiantes.Add(new Estudiante { NroCi = nroCi, Nombres = nombres, Apellidos = apellidos, Correo = correo, Codigo = codigo, Carrera = carrer });
        }

        private void AddProyecto(Estudiante estudiante, Docente docente, string titulo, string resumen, string gestion)
        {
            _context.ProyectoGrados.Add(new ProyectoGrado { Estudiante = estudiante, Docente = docente, Titulo = titulo, Resumen = resumen, Gestion = gestion });
        }

    }
}
