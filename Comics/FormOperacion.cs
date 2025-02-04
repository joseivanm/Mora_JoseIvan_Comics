using ComicADO;
using Entidades;
using Ventas;

namespace Comics
{
    public partial class FormOperacion : Form
    {
        private Empleado empleadoActual;
        private Local nombreLocal;
        private bool compra = false;
        public FormOperacion(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;
            txtEmpleado.Text = empleadoActual.Nombre;
            //using (LocalEmpleadoADO localEmpleadoADO = new LocalEmpleadoADO())
            using (VentasADO ventasADO = new VentasADO())
            {
                // Obtener la relación LocalEmpleado del empleado actual
                //LocalEmpleado localEmpleado = localEmpleadoADO.Listar(Convert.ToString(empleadoActual.EmpleadoId));
                LocalEmpleado localEmpleado = ventasADO.LocalEmpleado(Convert.ToString(empleadoActual.EmpleadoId));
                nombreLocal = ventasADO.ObtenerLocalPorId(Convert.ToString(localEmpleado.LocalId));
                //nombreLocal = localADO.ObtenerLocalPorId(Convert.ToString(localEmpleado.LocalId));
                // Verificar si localEmpleado es nulo (si no existe relación)
                int localSeleccionado = nombreLocal.LocalId;

                //using (StockComicADO stockComicADO = new StockComicADO())
                {
                    var editorialesDeTienda = ventasADO.ListarEditorialesPorTienda(localSeleccionado);
                    //var editorialesDeTienda = stockComicADO.ListarEditorialesPorTienda(localSeleccionado);


                    cmbEditorial.DataSource = editorialesDeTienda;
                    cmbEditorial.DisplayMember = "Nombre";
                    cmbEditorial.ValueMember = "EditorialId";

                    cmbEditoriales.DataSource = editorialesDeTienda;
                    cmbEditoriales.DisplayMember = "Nombre";
                    cmbEditoriales.ValueMember = "EditorialId";

                }
                if (localEmpleado != null)
                {
                    // Obtener el objeto Local relacionado


                    // Ahora, si la propiedad que deseas mostrar es 'Nombre', por ejemplo:
                    txtEmpleadoNif.Text = nombreLocal.Nombre; // Usar la propiedad que desees del objeto Local
                }
                else
                {
                    txtEmpleadoNif.Text = "No asignado a un local"; // O alguna otra lógica de manejo
                }
            }
            dgvOperacion.EditingControlShowing += dgvOperacion_EditingControlShowing;
            dgvOperacion.CellEndEdit += dgvOperacion_CellEndEdit;
            dgvOperacion.CellValueChanged += dgvOperacion_CellValueChanged;


        }

        private void rbVenta_CheckedChanged(object sender, EventArgs e)
        {
           
            cmbEditoriales.Enabled = false;
            texboxCantidad.Enabled = false;
            txtPrecioCompra.Enabled = false;
            txtPrecioCompra.Enabled = false;
            cmbMetodoPagoAdd.Enabled = false;
            btnCreateComic.Enabled = false;
            btnCargarComicsAdd.Enabled = false;
            cmbNombreComicAdd.Enabled = false;
            rbCliente.Enabled = false;
            btnVenta.Text = "Completar Venta";

            cmbEditorial.Enabled = true;
            btnLoadComics.Enabled = true;
            btnAddComic.Enabled = true;
            cmbMetodoPago.Enabled = true;
            btnVenta.Enabled = true;
            btnRemoveComic.Enabled = true;
            dgvOperacion.Enabled = true;
            cmbComics.Enabled = true;
            compra = false;

            dgvOperacion.Rows.Clear();
            txtSubtotal.Text = "0.00";
            txtIVA.Text = "0.00";
            txtTotal.Text = "0.00";

            using (VentasADO ventasADO = new VentasADO())
            {
                //metodo listar medios de pago
                List<MedioDePago> medioDePagos = ventasADO.ListarMediosDePago();
                cmbMetodoPago.DataSource = medioDePagos;
                cmbMetodoPago.DisplayMember = "NombreCorto";
                cmbMetodoPago.ValueMember = "MedioDePagoID";

                //metodo listar clientes
                List<ClienteJIM> clientes = ventasADO.ListarClientes();
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "NombreConNif";
                cmbClientes.ValueMember = "ClienteId";

            }

        }

        private void rbCompra_CheckedChanged(object sender, EventArgs e)
        {
            /*cmbEditorial.Enabled = false;
            btnLoadComics.Enabled = false;
            btnAddComic.Enabled = false;
            cmbMetodoPago.Enabled = false;
            btnVenta.Enabled = false;
            btnRemoveComic.Enabled = false;
            dgvOperacion.Enabled = false;
            cmbComics.Enabled = false;*/

            cmbEditoriales.Enabled = true;
            texboxCantidad.Enabled = true;
            txtPrecioCompra.Enabled = true;
            cmbMetodoPagoAdd.Enabled = true;
            btnCreateComic.Enabled = true;
            btnCargarComicsAdd.Enabled = true;
            cmbNombreComicAdd.Enabled = true;
            rbCliente.Enabled = true;
            compra = true;
            btnVenta.Text = "Completar Compra";

            using (VentasADO ventasADO = new VentasADO())
            {
                List<MedioDePago> medioDePagos = ventasADO.ListarMediosDePago();
                cmbMetodoPagoAdd.DataSource = medioDePagos;
                cmbMetodoPagoAdd.DisplayMember = "NombreCorto";
                cmbMetodoPagoAdd.ValueMember = "MedioDePagoID";
            }

        }

        private void btnLoadComics_Click(object sender, EventArgs e)
        {

            using (VentasADO ventasADO = new VentasADO())
            //using (StockComicADO stockADO = new StockComicADO())
            {
                // Verificar que haya una editorial y una tienda seleccionada
                if (cmbEditorial.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona una editorial y una tienda.");
                    return;  // Si no se selecciona alguno, salir de la función
                }
                // Obtener el EditorialId del ComboBox
                int editorialId = (int)cmbEditorial.SelectedValue;
                // Obtener el LocalId del ComboBox de tiendas
                int localId = nombreLocal.LocalId; // Suponiendo que tienes un ComboBox para las tiendas

                // Llamar al método que filtra por editorial y local
                List<Comic> comics = ventasADO.ListarPorEditorialYLocal(editorialId.ToString(), localId);

                string comicDetails = string.Empty;

                List<Comic> comicsConStock = new List<Comic>();

                foreach (var comic in comics)
                {
                    // Obtener el stock para el cómic actual
                    //var stockComic = stockADO.ListarPorComicId(comic.ComicId);
                    var stockComic = ventasADO.ListarPorComicId(comic);

                    if (stockComic != null && stockComic.Cantidad > 0) // Verificar si hay stock
                    {
                        comicsConStock.Add(comic); // Añadir a la lista si tiene stock > 0
                    }
                }



                cmbComics.DataSource = null;

                // Si hay comics, cargarlos en el ComboBox
                cmbComics.DataSource = comicsConStock;
                cmbComics.DisplayMember = "Nombre";
                cmbComics.ValueMember = "ComicId";
            }
        }


        private void btnAddComic_Click(object sender, EventArgs e)
        {
            if (cmbComics.SelectedItem != null)
            {
                // Obtener el comic seleccionado
                var comic = (Comic)cmbComics.SelectedItem;

                using (VentasADO ventasADO = new VentasADO())
                {

                    // Buscar si el comic ya está en el DataGridView
                    bool comicExists = false;

                    foreach (DataGridViewRow row in dgvOperacion.Rows)
                    {
                        if (row.Cells["Comic"].Value.ToString() == comic.Nombre)
                        {
                            int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);

                            var stockComic = ventasADO.ListarPorComicId(comic);
                            //var stockComic = stockADO.ListarPorComicId(comic.ComicId);

                            // Verificar si se supera el stock
                            if (cantidadActual + 1 > stockComic.Cantidad)
                            {
                                MessageBox.Show("No puedes agregar más unidades. Se ha alcanzado el límite de stock.");
                                return;
                            }

                            int currentQuantity = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            currentQuantity++;
                            row.Cells["Cantidad"].Value = currentQuantity;

                            // Recalcular el subtotal
                            decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                            decimal descuento = Convert.ToDecimal(row.Cells["Descuento"].Value);
                            decimal subtotal = (currentQuantity * precio) - ((currentQuantity * precio) * (descuento / 100));

                            row.Cells["Subtotal"].Value = subtotal.ToString("F2");
                            row.Cells["Stock"].Value = stockComic.Cantidad;

                            comicExists = true;
                            break;
                        }
                    }

                    // Si el comic no estaba en la tabla, agregar una nueva fila
                    if (!comicExists)
                    {

                        // Crear una nueva fila con los valores del comic
                        var row = new DataGridViewRow();
                        var stockComic = ventasADO.ListarPorComicId(comic);
                        //var stockComic = stockADO.ListarPorComicId(comic.ComicId);

                        // Verificar si se supera el stock

                        row.Cells.Add(new DataGridViewTextBoxCell { Value = comic.Nombre });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = comic.ComicId });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = 1 });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = comic.PrecioVenta });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = 0 });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = comic.PrecioVenta });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = stockComic.Cantidad });

                        // Añadir la fila al DataGridView
                        dgvOperacion.Rows.Add(row);
                    }
                }

                //Calcular Total
                CalcularTotales();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cómic.");
            }
        }

        private void dgvOperacion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (e.Control is TextBox txtEdit)
            {
                // Eliminar cualquier evento previo para evitar múltiples suscripciones
                txtEdit.KeyPress -= TxtEdit_KeyPress;

                // Agregar el evento personalizado para validar la entrada
                txtEdit.KeyPress += TxtEdit_KeyPress;
            }
        }

        private void TxtEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

  
            var currentColumn = dgvOperacion.Columns[dgvOperacion.CurrentCell.ColumnIndex];

      
            if (currentColumn.Name == "Cantidad")
            {
                // Permitir solo numeros 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; 
                }
            }
            // Validacion Precio y Descuento
            else if (currentColumn.Name == "Precio" || currentColumn.Name == "Descuento")
            {
                // Permitir numeros y coma
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true; 
                }

                // Permitir solo una coma decimal
                if (e.KeyChar == ',' && txt != null && txt.Text.Contains(","))
                {
                    e.Handled = true; 
                }
            }
        }



        private void dgvOperacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la edición ha ocurrido en las columnas de Cantidad, Precio o Descuento
            if (e.RowIndex >= 0 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4))
            {
                // Obtener los valores de las celdas de la fila actual
                var cantidadCell = dgvOperacion.Rows[e.RowIndex].Cells["Cantidad"];
                var precioCell = dgvOperacion.Rows[e.RowIndex].Cells["Precio"];
                var descuentoCell = dgvOperacion.Rows[e.RowIndex].Cells["Descuento"];
                var subtotalCell = dgvOperacion.Rows[e.RowIndex].Cells["Subtotal"];
                var stockCell = dgvOperacion.Rows[e.RowIndex].Cells["Stock"];

                // Verificar que los valores son válidos
                if (decimal.TryParse(cantidadCell.Value.ToString(), out decimal cantidad) &&
                    decimal.TryParse(precioCell.Value.ToString(), out decimal precio) &&
                    decimal.TryParse(descuentoCell.Value.ToString(), out decimal descuento) &&
                    int.TryParse(stockCell.Value.ToString(), out int stock))
                {
                    // Verificar si la cantidad excede el stock disponible
                    if (cantidad > stock)
                    {
                        MessageBox.Show("No puedes agregar más unidades. Se ha alcanzado el límite de stock.");


                        cantidadCell.Value = stock;
                        cantidad = stock;
                    }

                    // Calcular el subtotal (Cantidad * Precio) - (Descuento aplicado)
                    decimal subtotal = (cantidad * precio) - ((cantidad * precio) * (descuento / 100));

                    // Actualizar el subtotal en la celda correspondiente
                    subtotalCell.Value = subtotal.ToString("F2"); // Formato con 2 decimales
                }
                else
                {
                    subtotalCell.Value = "0.00";
                }

                CalcularTotales();
            }
        }

        private void dgvOperacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cell = dgvOperacion.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var currentColumn = dgvOperacion.Columns[e.ColumnIndex];

                // Validar contenido segun la columna
                if (currentColumn.Name == "Cantidad")
                {
                    // Validar que sea un numero entero
                    if (!int.TryParse(Convert.ToString(cell.Value), out int cantidad) || cantidad < 0)
                    {
                        MessageBox.Show("Por favor, introduce un valor numérico válido para la cantidad.");
                        cell.Value = 0; // Valor predeterminado
                    }
                }
                else if (currentColumn.Name == "Precio" || currentColumn.Name == "Descuento")
                {
                    // Validar que sea un numero decimal con coma
                    if (!decimal.TryParse(Convert.ToString(cell.Value)?.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal valor) || valor < 0)
                    {
                        MessageBox.Show("Por favor, introduce un valor decimal válido para precio o descuento.");
                        cell.Value = "0,00"; // Valor predeterminado
                    }
                }
            }
        }

        public void RefrescarClientes()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                List<ClienteJIM> clientes = ventasADO.ListarClientes();
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "NombreConNif";
                cmbClientes.ValueMember = "ClienteId";
            }
        }
        private void CalcularTotales()
        {
            decimal subtotal = 0;

            // Recorrer todas las filas para calcular el subtotal
            foreach (DataGridViewRow row in dgvOperacion.Rows)
            {
                // Asegurarse de que la fila no esté vacía y tenga valor en la columna Subtotal
                if (row.Cells["Subtotal"].Value != null)
                {
                    // Sumar el valor de la columna Subtotal
                    subtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            // Mostrar el subtotal en el TextBox correspondiente
            txtSubtotal.Text = subtotal.ToString("F2");

            // Calcular el IVA (21%)
            decimal iva = subtotal * 0.21m;
            txtIVA.Text = iva.ToString("F2");

            // Calcular el total con el IVA incluido
            decimal total = subtotal + iva;
            txtTotal.Text = total.ToString("F2");
        }


        private void btnRemoveComic_Click(object sender, EventArgs e)
        {
            if (dgvOperacion.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOperacion.SelectedRows)
                {
                    dgvOperacion.Rows.Remove(row); // Eliminar las filas seleccionadas
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un comic para eliminar.");
            }
        }





        private void btnAddClientes_Click(object sender, EventArgs e)
        {
            using (var formAñadirCliente = new FormAltaCliente())
            {
                if (formAñadirCliente.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        private void btnCreateComic_Click(object sender, EventArgs e)
        {

            try
            { // Validar y obtener datos
                if (cmbMetodoPagoAdd.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona valores válidos para Autor, Editorial, Tienda y metodo de pago.");
                    return;
                }

                int editorial = Convert.ToInt32(cmbEditoriales.SelectedValue);
                int local = nombreLocal.LocalId;
                int metodoPago = Convert.ToInt32(cmbMetodoPagoAdd.SelectedValue);
                int empleadoId = empleadoActual.EmpleadoId;
                int clienteId = Convert.ToInt32(cmbClientes.SelectedValue);

                int comicId = Convert.ToInt32(cmbNombreComicAdd.SelectedValue);

                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra))
                {
                    MessageBox.Show("El Precio de Compra debe ser un número decimal.");
                    return;
                }


                if (!int.TryParse(texboxCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número entero.");
                    return;
                }

                using (VentasADO ventasADO = new VentasADO())
                {
                    if (!rbCliente.Checked) { ventasADO.EditarStockComic(comicId, editorial, local, precioCompra, cantidad, metodoPago, empleadoId); }
                    else { ventasADO.EditarStockComic(comicId, editorial, local, precioCompra, cantidad, metodoPago, empleadoId, clienteId); }
                }
                //cmbAutores.SelectedIndex = -1;
                //cmbEditoriales.SelectedIndex = -1;
                texboxCantidad.Text = "";
                txtPrecioCompra.Text = "";
                //cmbTienda.SelectedIndex = -1;
                //cmbMetodoPagoAdd.SelectedIndex = -1;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el comic: {ex.Message}");
            }

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOperacion.Rows.Count == 0)
                {
                    MessageBox.Show("No hay cómics en la operación. Agrega al menos uno para realizar la venta.");
                    return;
                }
                if (cmbMetodoPago.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona un método de pago.");
                    return;
                }
                if (cmbClientes.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona un cliente.");
                    return;
                }

                //using (OperacionADO operacionADO = new OperacionADO())
                using (VentasADO ventasADO = new VentasADO())

                {
                    Operacion detalleOperacion = new Operacion();

                    int medioPago = (int)cmbMetodoPago.SelectedValue;
                    int localID = nombreLocal.LocalId;
                    int empleadoId = empleadoActual.EmpleadoId;
                    int clienteId = (int)cmbClientes.SelectedValue;

                    if (compra == false)
                    {
                        detalleOperacion = ventasADO.VenderComicOperacion(medioPago, localID, empleadoId, clienteId);
                    }
                    else
                    {
                        detalleOperacion = ventasADO.ComprarComicOperacion(medioPago, localID, empleadoId, clienteId);
                    }
                    int operacionId = detalleOperacion.OperacionId;


                    // Recorrer las filas del DataGridView para registrar una operación por cada cómic
                    foreach (DataGridViewRow row in dgvOperacion.Rows)
                    {
                        if (row.Cells["ComicId"].Value != null)
                        {
                            // Usar TryParse para asegurar la conversión segura a int
                            if (!int.TryParse(row.Cells["ComicId"].Value.ToString(), out int comicId))
                            {
                                MessageBox.Show("Error al obtener el ComicId." + row.Cells["ComicId"].Value);
                                return;
                            }

                            if (!int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad))
                            {
                                MessageBox.Show("Error al obtener la cantidad.");
                                return;
                            }

                            if (!decimal.TryParse(row.Cells["Precio"].Value.ToString(), out decimal precio))
                            {
                                MessageBox.Show("Error al obtener el precio.");
                                return;
                            }

                            if (!decimal.TryParse(row.Cells["Descuento"].Value.ToString(), out decimal descuento))
                            {
                                MessageBox.Show("Error al obtener el descuento.");
                                return;
                            }




                            if (compra == false)
                            {
                                ventasADO.VenderComicDetalles(comicId, cantidad, precio, descuento, operacionId);
                            }
                            else
                            {
                                ventasADO.ComprarComicDetalles(comicId, cantidad, precio, descuento, operacionId);
                            }
                        }
                    }

                    MessageBox.Show("Venta registrada exitosamente.");
                }

                // Limpiar la interfaz
                dgvOperacion.Rows.Clear();
                txtSubtotal.Text = "0.00";
                txtIVA.Text = "0.00";
                txtTotal.Text = "0.00";
                cmbEditorial.SelectedIndex = -1;
                cmbComics.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}");
            }
        }



       
        private void cmbEditorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                if (cmbEditorial.SelectedValue != null)
                {
                    int tiendaId = nombreLocal.LocalId;
                    int editorialId = (int)cmbEditorial.SelectedValue;

                    // Filtrar los cómics de la tienda y editorial seleccionada
                    var comicsDeEditorial = ventasADO.ListarComicsPorTiendaYEditorial(tiendaId, editorialId);
                    //var comicsDeEditorial = stockComicADO.ListarComicsPorTiendaYEditorial(tiendaId, editorialId);

                    // Cargar los cómics filtrados en el ComboBox
                    cmbComics.DataSource = comicsDeEditorial;
                    cmbComics.DisplayMember = "Nombre";
                    cmbComics.ValueMember = "ComicId";
                }
            }
        }

        private void cmbComics_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                if (cmbComics.SelectedValue != null)
                {
                    int comicId = (int)cmbComics.SelectedValue;
                    int tiendaId = nombreLocal.LocalId;

                    // Obtener detalles del cómic y cantidad disponible en stock
                    var stockComic = ventasADO.ListarPorComicYTienda(comicId, tiendaId);
                    //var stockComic = stockComicADO.ListarPorComicYTienda(comicId, tiendaId);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCargarComicsAdd_Click(object sender, EventArgs e)
        {

            using (VentasADO ventasADO = new VentasADO())
            {
                // Verificar que haya una editorial y una tienda seleccionada
                if (cmbEditorial.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona una editorial y una tienda.");
                    return;  // Si no se selecciona alguno, salir de la función
                }
                // Obtener el EditorialId del ComboBox
                int editorialId = (int)cmbEditoriales.SelectedValue;
                // Obtener el LocalId del ComboBox de tiendas
                int localId = nombreLocal.LocalId; // Suponiendo que tienes un ComboBox para las tiendas

                // Llamar al método que filtra por editorial y local
                List<Comic> comics = ventasADO.ListarPorEditorialYLocal(editorialId.ToString(), localId);

                string comicDetails = string.Empty;

                List<Comic> comicsConStock = new List<Comic>();

                foreach (var comic in comics)
                {
                    // Obtener el stock para el cómic actual

                    //var stockComic = stockADO.ListarPorComicId(comic.ComicId);
                    var stockComic = ventasADO.ListarPorComicId(comic);

                    if (stockComic != null && stockComic.Cantidad > 0) // Verificar si hay stock
                    {
                        comicsConStock.Add(comic); // Añadir a la lista si tiene stock > 0
                    }
                }



                cmbNombreComicAdd.DataSource = null;

                // Si hay comics, cargarlos en el ComboBox
                cmbNombreComicAdd.DataSource = comicsConStock;
                cmbNombreComicAdd.DisplayMember = "Nombre";
                cmbNombreComicAdd.ValueMember = "ComicId";
            }
        }
    }
}
