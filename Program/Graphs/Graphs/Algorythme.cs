namespace Graphs;

public class Algorythme
{
    // Matrice d'adjacence
    private static int[,] _matriceAdj =
    {
        {0, 1, 0, 0, 1, 0},
        {1, 0, 1, 0, 1, 1},
        {0, 1, 0, 1, 0, 1},
        {0, 0, 1, 0, 0, 1},
        {1, 1, 0, 0, 0, 0},
        {0, 1, 1, 1, 0, 0},
    };
    
    // Matrice d'incidence
    private static int[,] _matriceInc =
    {
        {1, 1, 0, 0, 0, 0, 0, 0},
        {1, 0, 1, 1, 1, 0, 0, 0},
        {0, 0, 0, 1, 0, 1, 1, 0},
        {0, 0, 0, 0, 0, 0, 1, 1},
        {0, 1, 1, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 1, 1, 0, 1},
    };
    
    //Variable representant le nombre d'etapes dans une methodes donnees
    private static int _count;
    
    /// <summary>
    /// Sert a reinitialiser la valeur du nombre d'etapes pour une methodes donnees
    /// </summary>
    private static void ResetCount()
    {
        _count = 0;
    }

    /// <summary>
    /// main du programme
    /// </summary>
    private static void Main()
    {
        Console.WriteLine("Pour la matrice d'adjacence: \n");
        Console.WriteLine("Le nombre de sommets: " + MatriceAdjSommets() + " avec " + _count + " iteration\n");
        ResetCount();
        Console.WriteLine("Le nombre d'arcs: " + MatriceAdjArcs() + " avec " + _count + " iteration\n");
        ResetCount();
        Console.WriteLine(MatriceAdjDegree() + "\n Avec " + _count + " iteration");
        ResetCount();
        if (CheckCycleAdj())
        {
            Console.WriteLine("Ce graphe admet un cycle avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'admet pas de cycle avec " + _count + " iteration\n");
        }

        ResetCount();
        if (CheckIfCyEulerienAdj())
        {
            Console.WriteLine("Ce graphe admet un cycle eulerien avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'admet pas de cycle eulerien avec " + _count + " iteration\n");
        }
        ResetCount();
        if (CheckIfChEulerienAdj())
        {
            Console.WriteLine("Ce graphe admet une chaine eulerienne avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'admet pas de chaine eulerienne avec " + _count + " iteration\n");
        }
        ResetCount();
        if (CheckIfPlannaireAdj())
        {
            Console.WriteLine("Ce graphe est planaire avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'est pas planaire " + _count + " iteration\n");
        }
        ResetCount();
        
        Console.WriteLine("\nPour la matrice d'incidence: \n");
        Console.WriteLine("Le nombre de sommets: " + MatriceIncSommets() + " avec " + _count + " iteration\n");
        ResetCount();
        Console.WriteLine("Le nombre d'arcs: " + MatriceIncArcs() + " avec " + _count + " iteration\n");
        ResetCount();
        Console.WriteLine(MatriceIncDegree() + "\n Avec " + _count + " iteration");
        ResetCount();
        if (CheckCycleInc())
        {
            Console.WriteLine("Ce graphe admet un cycle avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'admet pas de cycle avec " + _count + " iteration\n");
        }
        ResetCount();
        if (CheckIfCyEulerienInc())
        {
            Console.WriteLine("Ce graphe admet un cycle eulerien avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'admet pas de cycle eulerien avec " + _count + " iteration\n");
        }
        ResetCount();
        if (CheckIfChEulerienInc())
        {
            Console.WriteLine("Ce graphe admet une chaine eulerienne avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'admet pas de chaine eulerienne avec " + _count + " iteration\n");
        }
        ResetCount();
        if (CheckIfPlannaireInc())
        {
            Console.WriteLine("Ce graphe est planaire avec " + _count + " iteration\n");
        }
        else
        {
            Console.WriteLine("Ce graphe n'est pas planaire " + _count + " iteration\n");
        }
        ResetCount();
    }

    //   Algorythmes Matrice d'adjancence
    /// <summary>
    /// Parcours de la matrice d'adjacence pour determiner son nombre de lignes (nombres de sommets)
    /// </summary>
    /// <returns>Nombre de sommets</returns>
    private static int MatriceAdjSommets()
    {
        int sommets = 0;
        for (int i = 0; i < _matriceAdj.GetLength(0); i++)
        {
            _count++;
            sommets++;
        }

        return sommets;
    }
    /// <summary>
    /// Parcours de la matrice d'adjacence pour determiner le nombre de 1 dans la matrice
    /// Nombre de 1 = arcs / 2
    /// </summary>
    /// <returns>Nombre d'arcs</returns>
    private static int MatriceAdjArcs()
    {
        int arcs = 0;
        for (int i = 0; i < _matriceAdj.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceAdj.GetLength(1); j++)
            {
                _count++;
                if (_matriceAdj[i,j] == 1)
                {
                    arcs++;
                }
                
            }
        }

        return arcs / 2;
    }
    
    /// <summary>
    /// Parcours de la matrice d'adjacence pour determiner le nombre de 1 par ligne.
    /// Nombre de 1 par ligne = Degree pour chaque ligne/lettre
    /// </summary>
    /// <returns>Degree de chaque lettre</returns>
    private static string MatriceAdjDegree()
    {
        int[] degreeParLettre = new int[_matriceAdj.GetLength(0)];
        int degree = 0;
        for (int i = 0; i < _matriceAdj.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceAdj.GetLength(1); j++)
            {
                _count++;
                if (_matriceAdj[i, j] == 1)
                {
                    degree++;
                }
            }

            degreeParLettre[i] = degree;
            degree = 0;
        }

        return "Degree du sommet A: " + degreeParLettre[0] + 
               "\nDegree du sommet B: " + degreeParLettre[1] + 
               "\nDegree du sommet C: " + degreeParLettre[2] +
               "\nDegree du sommet D: " + degreeParLettre[3] + 
               "\nDegree du sommet E: " + degreeParLettre[4] + 
               "\nDegree du sommet F: " + degreeParLettre[5];
    }
    
    /// <summary>
    /// Methode recursive permettant de parcourirs la matrice d'adjacence a
    /// la recherche d'un cylce partant d'un sommet donner
    /// </summary>
    /// <param name="sommet">Un sommet de la matrice</param>
    /// <param name="visiter">Les sommets visiter</param>
    /// <param name="sommetPresent">Le sommet rendu dans la recherche d'un cycle</param>
    /// <returns>retourne true si il y a precense d'un cylce a ce sommet, sinon false</returns>
    private static bool MatriceCycleAdj(int sommet, bool[] visiter, bool[] sommetPresent)
    {
        if (sommetPresent[sommet])
        {
            return true;
        }
        if (visiter[sommet])
        {
            return false;
        }
        visiter[sommet] = true;
        sommetPresent[sommet] = true;
        for (int i = 0; i < _matriceAdj.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceAdj.GetLength(1); j++)
            {
                _count++;
                if (_matriceAdj[i, j] == 1)
                {
                    if (MatriceCycleAdj(i, visiter, sommetPresent))
                    {
                        return true;
                    }
                }
            }
        }
        sommetPresent[sommet] = false;
        return false;
    }
    
    /// <summary>
    /// Methode permettant de determiner si la matrice d'adjacence
    /// possede un cycle ou non partant de different points.
    /// </summary>
    /// <returns>retourne true s'il y a presence d'un cycle</returns>
    private static bool CheckCycleAdj()
    {
        int k = _matriceAdj.GetLength(0);
        bool[] visiter = new bool[k];
        bool[] sommetPresent = new bool[k];
        for (int i = 0; i < k; i++)
        {
            _count++;
            if (MatriceCycleAdj(i, visiter, sommetPresent))
            {
                return true;
            }
            
        }

        return false;
    }
    
    /// <summary>
    /// Cette methode sert a verifier si le graph admet un cycle eulerien
    /// </summary>
    /// <returns>true si il admet un cycle eulerien, sinon false</returns>
    private static bool CheckIfCyEulerienAdj()
    {
        int[] degreeParLettre = new int[_matriceAdj.GetLength(0)];
        int degree = 0;
        for (int i = 0; i < _matriceAdj.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceAdj.GetLength(1); j++)
            {
                _count++;
                if (_matriceAdj[i, j] == 1)
                {
                    degree++;
                }
            }

            degreeParLettre[i] = degree;
            if (degree % 2 != 0)
            {
                return false;
            }
            degree = 0;
        }

        return true;
    }
    
    /// <summary>
    /// Cette methode sert a verifier si le graph admet une chaine eulerienne
    /// </summary>
    /// <returns>true si il admet une chaine eulerienne, sinon false</returns>
    private static bool CheckIfChEulerienAdj()
    {
        int degreeImp = 0;
        int[] degreeParLettre = new int[_matriceAdj.GetLength(0)];
        int degree = 0;
        for (int i = 0; i < _matriceAdj.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceAdj.GetLength(1); j++)
            {
                _count++;
                if (_matriceAdj[i, j] == 1)
                {
                    degree++;
                }
            }

            degreeParLettre[i] = degree;
            if (degree % 2 != 0)
            {
                degreeImp++;
            }
            degree = 0;
        }

        if (degreeImp == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Cette methode verifie si le graph est planaire
    /// </summary>
    /// <returns>true si le graph est planaire, sinon false</returns>
    private static bool CheckIfPlannaireAdj()
    {
        if (MatriceAdjArcs() <= 3 * MatriceAdjSommets() - 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    //    Algorythmes Matrice d'incidence           
    /// <summary>
    /// Parcours de la matrice d'incidence pour determiner son nombre de lignes (nombres de sommets)
    /// </summary>
    /// <returns>Nombre de sommets</returns>
    private static int MatriceIncSommets()
    {
        int sommets = 0;
        for (int i = 0; i < _matriceInc.GetLength(0); i++)
        {
            _count++;
            sommets++;
        }

        return sommets;
    }
    
    /// <summary>
    /// Parcours de la matrice d'incidence pour determiner le nombre de 1 dans la matrice
    /// Nombre de 1 = arcs / 2
    /// </summary>
    /// <returns>Nombre d'arcs</returns>
    private static int MatriceIncArcs()
    {
        int arcs = 0;
        for (int i = 0; i < _matriceInc.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceInc.GetLength(1); j++)
            {
                _count++;
                if (_matriceInc[i,j] == 1)
                {
                    arcs++;
                }
            }
        }

        return arcs / 2;
    }
    
    /// <summary>
    /// Parcours de la matrice d'incidence pour determiner le nombre de 1 par ligne.
    /// Nombre de 1 par ligne = Degree pour chaque ligne/lettre
    /// </summary>
    /// <returns>Degree de chaque lettre</returns>
    private static string MatriceIncDegree()
    {
        int[] degreeParLettre = new int[_matriceAdj.GetLength(0)];
        int degree = 0;
        for (int i = 0; i < _matriceInc.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceInc.GetLength(1); j++)
            {
                _count++;
                if (_matriceInc[i, j] == 1)
                {
                    degree++;
                }
            }

            degreeParLettre[i] = degree;
            degree = 0;
        }

        return "Degree du sommet A: " + degreeParLettre[0] + 
               "\nDegree du sommet B: " + degreeParLettre[1] + 
               "\nDegree du sommet C: " + degreeParLettre[2] +
               "\nDegree du sommet D: " + degreeParLettre[3] + 
               "\nDegree du sommet E: " + degreeParLettre[4] + 
               "\nDegree du sommet F: " + degreeParLettre[5];
    }
    
    /// <summary>
    /// Methode recursive permettant de parcourirs la matrice d'incidence a
    /// la recherche d'un cylce partant d'un sommet donner
    /// </summary>
    /// <param name="sommet">Un sommet de la matrice</param>
    /// <param name="visiter">Les sommets visiter</param>
    /// <param name="sommetPresent">Le sommet rendu dans la recherche d'un cycle</param>
    /// <returns>retourne true si il y a precense d'un cylce a ce sommet, sinon false</returns>
    private static bool MatriceCycleInc(int sommet, bool[] visiter, bool[] sommetPresent)
    {
        if (sommetPresent[sommet])
        {
            return true;
        }
        if (visiter[sommet])
        {
            return false;
        }
        visiter[sommet] = true;
        sommetPresent[sommet] = true;
        for (int i = 0; i < _matriceInc.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceInc.GetLength(1); j++)
            {
                _count++;
                if (_matriceInc[i, j] == 1)
                {
                    if (MatriceCycleAdj(i, visiter, sommetPresent))
                    {
                        return true;
                    }
                }
            }
        }
        sommetPresent[sommet] = false;
        return false;
    }
    
    /// <summary>
    /// Methode permettant de determiner si la matrice d'incidence
    /// possede un cycle ou non partant de different points.
    /// </summary>
    /// <returns>retourne true s'il y a presence d'un cycle</returns>
    private static bool CheckCycleInc()
    {
        int k = _matriceInc.GetLength(0);
        bool[] visiter = new bool[k];
        bool[] sommetPresent = new bool[k];
        for (int i = 0; i < k; i++)
        {
            _count++;
            if (MatriceCycleInc(i, visiter, sommetPresent))
            {
                return true;
            }
        }

        return false;
    }
    
    /// <summary>
    /// Cette methode sert a verifier si le graph admet un cycle eulerien
    /// </summary>
    /// <returns>true si il admet un cycle eulerien, sinon false</returns>
    private static bool CheckIfCyEulerienInc()
    {
        int[] degreeParLettre = new int[_matriceInc.GetLength(0)];
        int degree = 0;
        for (int i = 0; i < _matriceInc.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceInc.GetLength(1); j++)
            {
                _count++;
                if (_matriceInc[i, j] == 1)
                {
                    degree++;
                }
            }

            degreeParLettre[i] = degree;
            if (degree % 2 != 0)
            {
                return false;
            }
            degree = 0;
        }

        return true;
    }
    
    /// <summary>
    /// Cette methode sert a verifier si le graph admet une chaine eulerienne
    /// </summary>
    /// <returns>true si il admet une chaine eulerienne, sinon false</returns>
    private static bool CheckIfChEulerienInc()
    {
        int degreeImp = 0;
        int[] degreeParLettre = new int[_matriceInc.GetLength(0)];
        int degree = 0;
        for (int i = 0; i < _matriceInc.GetLength(0); i++)
        {
            for (int j = 0; j < _matriceInc.GetLength(1); j++)
            {
                _count++;
                if (_matriceInc[i, j] == 1)
                {
                    degree++;
                }
            }

            degreeParLettre[i] = degree;
            if (degree % 2 != 0)
            {
                degreeImp++;
            }
            degree = 0;
        }

        if (degreeImp == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    /// <summary>
    /// Cette methode verifie si le graph est planaire
    /// </summary>
    /// <returns>true si le graph est planaire, sinon false</returns>
    private static bool CheckIfPlannaireInc()
    {
        if (MatriceIncArcs() <= 3 * MatriceIncSommets() - 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}