﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public interface IMedioDePagoRepository
    {
        List<MedioDePago> MediosDePago();
    }
}
