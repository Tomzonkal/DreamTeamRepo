#include <vector>
#include <iostream>
using namespace std;

class Matrix 
{
    public :
   
    Matrix multiply(double const&value);
    Matrix add(Matrix const&m)const;
    Matrix substract(Matrix const&m)const;
    Matrix multiply(Matrix const &m) const;
    Matrix dot(Matrix const &m) const;
    Matrix transpose() const;
    Matrix applyFunction(double (*function)(double)) const;
     
};
