using System.Diagnostics;
using System.Text;
using Practica2.Estructuras;

namespace Practica2.Graphviz;

public class GraphvizService
{
    // Gráfica de la cola
    public string GenerarCola(NodoCola? frente)
    {
        StringBuilder dot = new StringBuilder();

        dot.AppendLine("digraph Cola {");
        dot.AppendLine("rankdir=LR;");
        dot.AppendLine("node [shape=box];");

        NodoCola? actual = frente;

        int contador = 0;

        if (actual == null)
        {
            dot.AppendLine("vacio [label=\"Cola vacía\"];");
        }

        while (actual != null)
        {
            string titulo = Escapar(actual.Cancion.Titulo);
            string artista = Escapar(actual.Cancion.Artista);
            string genero = Escapar(actual.Cancion.Genero);

            dot.AppendLine(
                $"nodo{contador} " +
                $"[label=\"{titulo}\\n{artista}\\n{genero}\\n" +
                $"{actual.Cancion.Duracion} min\"];"
            );

            if (actual.Siguiente != null)
            {
                dot.AppendLine(
                    $"nodo{contador} -> nodo{contador + 1};"
                );
            }

            actual = actual.Siguiente;
            contador++;
        }

        dot.AppendLine("}");

        string rutaDot = Path.Combine( AppContext.BaseDirectory, "cola.dot");

        string rutaPng = Path.Combine(AppContext.BaseDirectory, "cola.png" );

        File.WriteAllText(rutaDot, dot.ToString());

        GenerarImagen(rutaDot, rutaPng);

        return rutaPng;
    }

    
    // gráfica del árbol
    public string GenerarArbol(NodoArbol? raiz)
    {
        StringBuilder dot = new StringBuilder();

        dot.AppendLine("digraph Arbol {");
        dot.AppendLine("node [shape=ellipse];");

        if (raiz == null)
        {
            dot.AppendLine("vacio [label=\"Árbol vacío\"];");
        }
        else
        {
            int contador = 0;

            GenerarNodoArbol( raiz, dot, ref contador);
        }

        dot.AppendLine("}");

        string rutaDot = Path.Combine(AppContext.BaseDirectory, "arbol.dot");

        string rutaPng = Path.Combine(AppContext.BaseDirectory, "arbol.png");

        File.WriteAllText(rutaDot, dot.ToString());

        GenerarImagen(rutaDot, rutaPng);

        return rutaPng;
    }


    private int GenerarNodoArbol(NodoArbol nodo, StringBuilder dot, ref int contador )
    {
        int idActual = contador;

        contador++;

        string titulo = Escapar(nodo.Cancion.Titulo);

        dot.AppendLine(
            $"nodo{idActual} " +
            $"[label=\"{titulo}\"];"
        );
        
        if (nodo.Izquierda != null)
        {
            int idIzquierda =
                GenerarNodoArbol(nodo.Izquierda, dot, ref contador);

            dot.AppendLine(
                $"nodo{idActual} -> " +
                $"nodo{idIzquierda} " +
                "[label=\"Izq\"];"
            );
        }
        
        if (nodo.Derecha != null)
        {
            int idDerecha =
                GenerarNodoArbol(nodo.Derecha, dot, ref contador);

            dot.AppendLine(
                $"nodo{idActual} -> " +
                $"nodo{idDerecha} " +
                "[label=\"Der\"];"
            );
        }

        return idActual;
    }
    
    // ejecutar graphviz
    private void GenerarImagen(string rutaDot, string rutaPng)
    {
        ProcessStartInfo proceso = new ProcessStartInfo();

        proceso.FileName = "dot";

        proceso.Arguments =
            $"-Tpng \"{rutaDot}\" " +
            $"-o \"{rutaPng}\"";

        proceso.UseShellExecute = false;
        proceso.CreateNoWindow = true;

        using Process? graphviz = Process.Start(proceso);

        graphviz?.WaitForExit();
    }
    
    private string Escapar(string texto)
    {
        return texto
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"");
    }
}