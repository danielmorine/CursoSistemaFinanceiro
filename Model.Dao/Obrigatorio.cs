using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{

    //CLASSE QUE FARÁ A INTERMEDIAÇÃO COM TODAS AS CLASSES
    public interface Obrigatorio<qualquerClasse>
    {
        void create(qualquerClasse obj);
        void update(qualquerClasse obj);
        void delete(qualquerClasse obj);
        bool find(qualquerClasse obj);

        List<qualquerClasse> findAll();
    }
}
