using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppParqueadero.Infraestructura.Datos.Migrations
{
    public partial class migarcionv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("0b6ac818-00d8-45ad-bddc-cde7c02fadbb"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("17d29544-23c1-4dcd-97f3-3dbc1ca31885"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("249ee805-b75b-4f49-9eba-f6fee7628377"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("2b4a2de9-1596-4c53-beea-418a26d44bac"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("4c76be66-0fc0-4646-a599-019f44c24608"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("60bd82ff-b63d-4649-b620-f6333de4dafb"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("65a344c7-9cc5-4e6b-9e74-bc0187ed81e9"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("803e074a-6484-4275-8e48-f50210a1ba38"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("bab08f42-2fa8-430b-88d5-6ec72c917f27"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("f3ba6f58-c4bf-45d5-8276-894bc29d2103"));

            migrationBuilder.DeleteData(
                table: "Tarifa",
                keyColumn: "TarifaId",
                keyValue: new Guid("7f609f85-596b-4a1e-9776-2acedf942319"));

            migrationBuilder.DeleteData(
                table: "Tarifa",
                keyColumn: "TarifaId",
                keyValue: new Guid("9d5ce7e2-678c-43a5-a6ea-df7a2d4c47ee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraDeSalida",
                table: "Ticked",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.InsertData(
                table: "Puesto",
                columns: new[] { "PuestoId", "CodigoPuesto", "Disponibilidad", "FechaModifica", "usuarioCrea", "usuarioModifica" },
                values: new object[,]
                {
                    { new Guid("b5f38779-158c-4c31-bda5-c41113f48adf"), "A0", "Disponible", null, null, null },
                    { new Guid("c863a900-6ecb-4aed-9ba1-0a537a806902"), "A1", "Disponible", null, null, null },
                    { new Guid("f948f608-5c73-46b8-844e-f05261d3814b"), "A2", "Disponible", null, null, null },
                    { new Guid("6438d933-2da6-47f8-bc8c-984b62f04215"), "A3", "Disponible", null, null, null },
                    { new Guid("e2a42931-a2fc-4b40-a695-227d1280bd46"), "A4", "Disponible", null, null, null },
                    { new Guid("0dc9061a-7a16-42da-aac4-d741e88519bf"), "A5", "Disponible", null, null, null },
                    { new Guid("0b33f6a1-b457-415b-b743-e28327ac2977"), "A6", "Disponible", null, null, null },
                    { new Guid("829afa9d-71f4-4214-b0eb-2e2fbd213bae"), "A7", "Disponible", null, null, null },
                    { new Guid("8f7c1123-1004-41de-8bca-97ac776df718"), "A8", "Disponible", null, null, null },
                    { new Guid("5b538258-62f2-48bc-873f-74eef86ea61a"), "A9", "Disponible", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tarifa",
                columns: new[] { "TarifaId", "FechaModifica", "Tipo", "Valor", "usuarioCrea", "usuarioModifica" },
                values: new object[,]
                {
                    { new Guid("918ee23d-a6ac-45ec-8b12-eeffa0220fcc"), null, "Auto", 3000m, null, null },
                    { new Guid("3654ecdd-0573-456c-b9b4-4aea3285a664"), null, "Moto", 1000m, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("0b33f6a1-b457-415b-b743-e28327ac2977"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("0dc9061a-7a16-42da-aac4-d741e88519bf"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("5b538258-62f2-48bc-873f-74eef86ea61a"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("6438d933-2da6-47f8-bc8c-984b62f04215"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("829afa9d-71f4-4214-b0eb-2e2fbd213bae"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("8f7c1123-1004-41de-8bca-97ac776df718"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("b5f38779-158c-4c31-bda5-c41113f48adf"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("c863a900-6ecb-4aed-9ba1-0a537a806902"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("e2a42931-a2fc-4b40-a695-227d1280bd46"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "PuestoId",
                keyValue: new Guid("f948f608-5c73-46b8-844e-f05261d3814b"));

            migrationBuilder.DeleteData(
                table: "Tarifa",
                keyColumn: "TarifaId",
                keyValue: new Guid("3654ecdd-0573-456c-b9b4-4aea3285a664"));

            migrationBuilder.DeleteData(
                table: "Tarifa",
                keyColumn: "TarifaId",
                keyValue: new Guid("918ee23d-a6ac-45ec-8b12-eeffa0220fcc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraDeSalida",
                table: "Ticked",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Puesto",
                columns: new[] { "PuestoId", "CodigoPuesto", "Disponibilidad", "FechaModifica", "usuarioCrea", "usuarioModifica" },
                values: new object[,]
                {
                    { new Guid("2b4a2de9-1596-4c53-beea-418a26d44bac"), "A0", "Disponible", null, null, null },
                    { new Guid("60bd82ff-b63d-4649-b620-f6333de4dafb"), "A1", "Disponible", null, null, null },
                    { new Guid("bab08f42-2fa8-430b-88d5-6ec72c917f27"), "A2", "Disponible", null, null, null },
                    { new Guid("17d29544-23c1-4dcd-97f3-3dbc1ca31885"), "A3", "Disponible", null, null, null },
                    { new Guid("803e074a-6484-4275-8e48-f50210a1ba38"), "A4", "Disponible", null, null, null },
                    { new Guid("4c76be66-0fc0-4646-a599-019f44c24608"), "A5", "Disponible", null, null, null },
                    { new Guid("65a344c7-9cc5-4e6b-9e74-bc0187ed81e9"), "A6", "Disponible", null, null, null },
                    { new Guid("f3ba6f58-c4bf-45d5-8276-894bc29d2103"), "A7", "Disponible", null, null, null },
                    { new Guid("0b6ac818-00d8-45ad-bddc-cde7c02fadbb"), "A8", "Disponible", null, null, null },
                    { new Guid("249ee805-b75b-4f49-9eba-f6fee7628377"), "A9", "Disponible", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tarifa",
                columns: new[] { "TarifaId", "FechaModifica", "Tipo", "Valor", "usuarioCrea", "usuarioModifica" },
                values: new object[,]
                {
                    { new Guid("7f609f85-596b-4a1e-9776-2acedf942319"), null, "Auto", 3000m, null, null },
                    { new Guid("9d5ce7e2-678c-43a5-a6ea-df7a2d4c47ee"), null, "Moto", 1000m, null, null }
                });
        }
    }
}
