interface IPresupuestoRepository
{
    void crearPresupuesto(Presupuesto unPresupuesto);
    
    List<Presupuesto> listarPresupuestos();
    
}