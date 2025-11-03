#!/bin/bash

# Script para ejecutar las pruebas del proyecto Máquina de Café

echo "=========================================="
echo "  Máquina de Café - Ejecutando Pruebas"
echo "=========================================="
echo ""

# Restaurar dependencias
echo "📦 Restaurando dependencias..."
dotnet restore
echo ""

# Compilar el proyecto
echo "🔨 Compilando proyecto..."
dotnet build MaquinaDeCafe/MaquinaDeCafe.csproj
echo ""

# Ejecutar las pruebas
echo "🧪 Ejecutando pruebas unitarias..."
dotnet test MaquinaDeCafe.Tests/MaquinaDeCafe.Tests.csproj --logger "console;verbosity=detailed"
echo ""

echo "=========================================="
echo "  ✅ Proceso completado"
echo "=========================================="
