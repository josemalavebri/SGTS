namespace SGTS.Business.Const;

public static class BusinessMessages
{
    public static class Usuario
    {
        public const string NO_ENCONTRADO = "Usuario no encontrado";
        public const string EMAIL_DUPLICADO = "El email ya está registrado";
        public const string NO_CREADO = "No se pudo crear el usuario";
        public const string NO_ACTUALIZADO = "No se pudo actualizar el usuario";
        public const string NO_ELIMINADO = "No se pudo eliminar el usuario";
    }

    public static class Reglas
    {
        public const string OPERACION_NO_PERMITIDA = "Esta operación no está permitida";
    }
}