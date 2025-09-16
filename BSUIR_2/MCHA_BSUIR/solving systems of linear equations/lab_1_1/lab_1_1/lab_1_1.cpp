    #include <iostream>
    #include <cmath>
    #include <iomanip>
    #include <vector>

    const double EPS = 1e-12;

    std::vector<std::vector<double>> sumMyMatrices(
        const std::vector<std::vector<double>>& A,
        const std::vector<std::vector<double>>& B) {

        int rowsA = A.size();
        int colsA = A[0].size();
        int rowsB = B.size();
        int colsB = B[0].size();

        if (rowsA != rowsB || colsA != colsB) {
            throw std::invalid_argument("Несовместимые размеры матриц для сложения");
        }

        std::vector<std::vector<double>> result(rowsA, std::vector<double>(colsB, 0.0));

        for (int i = 0; i < rowsA; i++) {
            for (int j = 0; j < colsA; j++) {
                result[i][j] = A[i][j] + B[i][j];
            }
        }

        return result;
    }

    std::vector<std::vector<double>> multiplintKAndMatrix(
        const std::vector<std::vector<double>>& A, const double k)
    {
        int rowsA = A.size();
        int colsA = A[0].size();

        std::vector<std::vector<double>> result(rowsA, std::vector<double>(colsA, 0.0));

        for (int i = 0; i < rowsA; i++) {
            for (int j = 0; j < colsA; j++) {
                result[i][j] = A[i][j] * k;
            }
        }

        return result;
    }   


    void printing(
        const std::vector<std::vector<double>>& A) {

        int rowsA = A.size();
        int colsA = A[0].size();


        for (int i = 0; i < rowsA; i++) {
            for (int j = 0; j < colsA; j++) {
                std::cout << A[i][j] << " ";
            }
            std::cout << std::endl;
        }

    }
    void printingSingle(
        const std::vector<double>& A) {

        for (int i = 0; i < A.size(); i++) {
            std::cout << A[i] << " ";
        }

    }
        
    bool basicGauss(std::vector<std::vector<double>>& A, std::vector<double>& b, std::vector<double>& x) {
        int n = A.size();     
        int m = A[0].size(); 

        std::vector<std::vector<double>>& copy_A = A;
        std::vector<double>& copy_b = b;


        if (n < m) {
            std::cerr << "Система недоопределена: возможно бесконечно много решений\n";
            return false;
        }

        std::vector<int> colIndex(m);
        for (int i = 0; i < m; i++) colIndex[i] = i;

        for (int k = 0; k < m; k++) {
            if (fabs(A[k][k]) < EPS) {
                bool found = false;
                for (int j = k + 1; j < m; j++) {
                    if (fabs(A[k][j]) > EPS) {
                        for (int i = 0; i < n; i++) std::swap(A[i][k], A[i][j]);
                        std::swap(colIndex[k], colIndex[j]);
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    if (fabs(b[k]) > EPS) {
                        std::cerr << "Система несовместна (нет решений)\n";
                        return false;
                    }
                    else {
                        std::cerr << "Система имеет бесконечно много решений\n";
                        return false;
                    }
                }
            }

            for (int i = k + 1; i < n; i++) {
                double factor = A[i][k] / A[k][k];
                for (int j = k; j < m; j++) {
                    A[i][j] -= factor * A[k][j];
                }
                b[i] -= factor * b[k];
            }
        }

        x.assign(m, 0.0);
        for (int i = m - 1; i >= 0; i--) {
            double sum = b[i];
            for (int j = i + 1; j < m; j++) {
                sum -= A[i][j] * x[j];
            }
            if (fabs(A[i][i]) < EPS) {
                if (fabs(sum) < EPS) {
                    std::cerr << "Система имеет бесконечно много решений\n";
                }
                else {
                    std::cerr << "Система несовместна\n";
                }
                return false;
            }
            x[i] = sum / A[i][i];
        }

        std::vector<double> xCorrect(m);
        for (int i = 0; i < m; i++) {
            xCorrect[colIndex[i]] = x[i];
        }
        x = xCorrect;

        
        for (int i = m; i < n; i++) {
            double sum = 0;
            for (int j = 0; j < m; j++) {
                sum += copy_A[i][j] * x[j];
            }
            if (fabs(sum - copy_b[i]) > EPS) {
                std::cerr << "Система несовместна\n";
                return false;
            }
        }

        return true;
    }


    bool MaxElementInColumnGauss(std::vector<std::vector<double>>& A, std::vector<double>& b, std::vector<double>& x) {
        int n = A.size(); 
        int m = A[0].size();  

        if (n < m) {
            std::cerr << "Система недоопределена: возможно бесконечно много решений\n";
            return false;
        }

        for (int k = 0; k < m; k++) {
            int maxRow = k;
            for (int i = k; i < n; i++) {
                if (fabs(A[i][k]) > fabs(A[maxRow][k])) {
                    maxRow = i;
                }
            }

            if (fabs(A[maxRow][k]) < EPS) {
                bool isZero = true;
                for (int l = k; l < n; l++) {
                    for (int v = k; v < n; v++) {
                        if (A[l][v] != 0) isZero = false;
                    }
                    if (isZero && fabs(b[l]) < EPS) {
                        std::cerr << "Система имеет бесконечно много решений\n";
                        return false;
                    }
                }

                std::cerr << "Система имеет бесконечно много решений\n";
                return false;
            }

            if (maxRow != k) {
                std::swap(A[k], A[maxRow]);
                std::swap(b[k], b[maxRow]);
            }

            for (int i = k + 1; i < n; i++) {
                double factor = A[i][k] / A[k][k];
                for (int j = k; j < m; j++) {
                    A[i][j] -= factor * A[k][j];
                }
                b[i] -= factor * b[k];
            }
        }

        x.assign(m, 0.0);
        for (int i = m - 1; i >= 0; i--) {
            double sum = b[i];
            for (int j = i + 1; j < m; j++) {
                sum -= A[i][j] * x[j];
            }
            if (fabs(A[i][i]) < EPS) {
                if (fabs(sum) < EPS) {
                    std::cerr << "Система имеет бесконечно много решений\n";
                }
                else {
                    std::cerr << "Система несовместна\n";
                }
                return false;
            }
            x[i] = sum / A[i][i];
        }

        for (int i = m; i < n; i++) {
            double sum = 0;
            for (int j = 0; j < m; j++) {
                sum += A[i][j] * x[j];
            }
            if (fabs(sum - b[i]) > EPS) {
                std::cerr << "Система несовместна\n";
                return false;
            }
        }

        return true;
    }


    bool MaxElementInMatrixGauss(std::vector<std::vector<double>>& A, std::vector<double>& b, std::vector<double>& x) {
        int n = A.size();
        int m = A[0].size();

        std::vector<std::vector<double>>& copy_A = A;
        std::vector<double>& copy_b = b;

        if (n < m) {
            std::cerr << "Система недоопределена: возможно бесконечно много решений\n";
            return false;
        }


        std::vector<int> colIndex(m);
        for (int i = 0; i < m; i++) colIndex[i] = i;

        for (int k = 0; k < m; k++) {

            double max = A[k][k];
            int indexColm = k;
            int indexRow = k;

            for (int i = k; i < n; i++) {
                for (int j = k; j < m; j++) {
                    if (fabs(max) < fabs(A[i][j])) {
                        max = A[i][j];
                        indexRow = i;
                        indexColm = j;
                    }
                }
            }

            if (fabs(A[indexRow][indexColm]) < EPS) {
                if (fabs(b[indexRow]) > EPS) {
                    std::cerr << "Система несовместна (нет решений)\n";
                }
                else {
                    std::cerr << "Система имеет бесконечно много решений\n";
                }
                return false;
            }

            if (indexRow != k) {
                std::swap(A[k], A[indexRow]);
                std::swap(b[k], b[indexRow]);
            }

            if (indexColm != k) {
                for (int r = 0; r < m; r++) std::swap(A[r][k], A[r][indexColm]);
                std::swap(colIndex[k], colIndex[indexColm]);
            }
            
            for (int i = k + 1; i < n; i++) {
                double q = A[i][k] / A[k][k];
                for (int j = k; j < m; j++) {
                    A[i][j] -= q * A[k][j];
                }

                b[i] -= q * b[k];
            }
        }

        x.assign(m, 0.0);
        for (int i = m - 1; i >= 0; i--) {
            double sum = b[i];
            for (int j = i + 1; j < m; j++) {
                sum -= A[i][j] * x[j];
            }
            if (fabs(A[i][i]) < EPS) {
                if (fabs(sum) < EPS) {
                    std::cerr << "Система имеет бесконечно много решений\n";
                }
                else {
                    std::cerr << "Система несовместна\n";
                }
                return false;
            }
            x[i] = sum / A[i][i];
        }

        std::vector<double> xCorrect(m);
        for (int i = 0; i < m; i++) {
            xCorrect[colIndex[i]] = x[i];
        }
        x = xCorrect;

        if (n > m) {
            for (int i = m; i < n; i++) {
                double sum = 0;
                for (int j = 0; j < m; j++) {
                    sum += copy_A[i][j] * x[j];
                }
                if (fabs(sum - copy_b[i]) > EPS) {
                    std::cerr << "Система несовместна\n";
                    return false;
                }
            }
        }
        return true;
    }

    


    std::vector<std::vector<double>> ADDIRIONALmultiplayMatrics(const std::vector<std::vector<double>>& A,
        const std::vector<std::vector<double>>& B)
        {
            int rowsA = A.size();
            int colsA = A[0].size();
            int rowsB = B.size();
            int colsB = B[0].size();

            if (colsA != rowsB){
                throw std::invalid_argument("Несовместимые размеры матриц для умножения");
            }

            std::vector<std::vector<double>> result(rowsA, std::vector<double>(colsB, 0.0));

            for (int k = 0; k < rowsA; k++) {
                for (int j = 0; j < colsB; j++) {
                    for (int i = 0; i < colsA; i++) {
                        result[k][j] += A[k][i] * B[i][j];
                    }
                }
            }

            return result;

    }





int main()
{
    setlocale(LC_ALL, "");

    

    std::vector<std::vector<double>> C = {
    {0.2, 0.0, 0.2, 0.0, 0.0},
    {0.0, 0.2, 0.0, 0.2, 0.0},
    {0.2, 0.0, 0.2, 0.0, 0.2},
    {0.0, 0.2, 0.0, 0.2, 0.0},
    {0.0, 0.0, 0.2, 0.0, 0.2}
    };

    std::vector<std::vector<double>> D = {
    {2.33, 0.81, 0.67, 0.92, -0.53},
    {-0.53, 2.33, 0.81, 0.67, 0.92},
    {0.92, -0.53, 2.33, 0.81, 0.67},
    {0.67, 0.92, -0.53, 2.33, 0.81},
    {0.81, 0.67, 0.92, -0.53, 2.33}
    };

    int k = 7;

    std::vector<std::vector<double>> A1 = sumMyMatrices(multiplintKAndMatrix(C, k), D);
    printing(A1);
    std::vector<std::vector<double>> A2 = sumMyMatrices(multiplintKAndMatrix(C, k), D);
    std::vector<std::vector<double>> A3 = sumMyMatrices(multiplintKAndMatrix(C, k), D);
    
    std::vector<double> b1 = { 4.2, 4.2, 4.2, 4.2, 4.2 };
    std::vector<double> b2 = { 4.2, 4.2, 4.2, 4.2, 4.2 };
    std::vector<double> b3 = { 4.2, 4.2, 4.2, 4.2, 4.2 };
    std::vector<double> x1;
    std::vector<double> x2;
    std::vector<double> x3;

    //printingSingle(b);


    basicGauss(A1, b1, x1);

    MaxElementInColumnGauss(A2, b2, x2);
    
    MaxElementInMatrixGauss(A3, b3, x3);


    //std::vector<std::vector<double>> m = { {1, 0}, {0, 1} };
    //std::vector<std::vector<double>> y = { { 1, 2 }, { 3, 4 } };

    //printing(ADDIRIONALmultiplayMatrics(m, y));

    printingSingle(x1);
    std::cout << std::endl;
    printingSingle(x2);
    std::cout << std::endl;
    printingSingle(x3);

    
    



    return 0;
}
