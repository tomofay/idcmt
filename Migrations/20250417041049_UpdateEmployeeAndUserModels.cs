using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indocement_RESTFullAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeAndUserModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "indocement");

            migrationBuilder.CreateTable(
                name: "cache",
                schema: "indocement",
                columns: table => new
                {
                    key = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cache_key", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "cache_locks",
                schema: "indocement",
                columns: table => new
                {
                    key = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    owner = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    expiration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cache_locks_key", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "esl",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jabatan = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_esl_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "failed_jobs",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    connection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    queue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    failed_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_failed_jobs_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_batches",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    total_jobs = table.Column<int>(type: "int", nullable: false),
                    pending_jobs = table.Column<int>(type: "int", nullable: false),
                    failed_jobs = table.Column<int>(type: "int", nullable: false),
                    failed_job_ids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    options = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "(NULL)"),
                    cancelled_at = table.Column<int>(type: "int", nullable: true, defaultValueSql: "(NULL)"),
                    created_at = table.Column<int>(type: "int", nullable: false),
                    finished_at = table.Column<int>(type: "int", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_batches_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    queue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    attempts = table.Column<byte>(type: "tinyint", nullable: false),
                    reserved_at = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    available_at = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "migrations",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    migration = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    batch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_migrations_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "password_reset_tokens",
                schema: "indocement",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_reset_tokens_email", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<decimal>(type: "numeric(20,0)", nullable: true, defaultValueSql: "(NULL)"),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true, defaultValueSql: "(NULL)"),
                    user_agent = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "(NULL)"),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_activity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama_unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plant_division",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_unit = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    nama_plant_division = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plant_division_id", x => x.id);
                    table.ForeignKey(
                        name: "plant_division$plant_division_id_unit_foreign",
                        column: x => x.id_unit,
                        principalSchema: "indocement",
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departement",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_plant_division = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    nama_departement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departement_id", x => x.id);
                    table.ForeignKey(
                        name: "departement$departement_id_plant_division_foreign",
                        column: x => x.id_plant_division,
                        principalSchema: "indocement",
                        principalTable: "plant_division",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "section",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_departement = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    nama_section = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_id", x => x.id);
                    table.ForeignKey(
                        name: "section$section_id_departement_foreign",
                        column: x => x.id_departement,
                        principalSchema: "indocement",
                        principalTable: "departement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    employee_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    job_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    service_date = table.Column<DateOnly>(type: "date", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    no_bpjs = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    telepon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, defaultValueSql: "(NULL)"),
                    living_area = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(NULL)"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    education = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    work_location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_section = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    id_esl = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    url_foto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_id", x => x.id);
                    table.ForeignKey(
                        name: "employee$employee_id_esl_foreign",
                        column: x => x.id_esl,
                        principalSchema: "indocement",
                        principalTable: "esl",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "employee$employee_id_section_foreign",
                        column: x => x.id_section,
                        principalSchema: "indocement",
                        principalTable: "section",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bpjs",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_employee = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    tgl_pengajuan = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    anggota_bpjs = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    anak_ke = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    url_kk = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    url_surat_nikah = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    url_akte_lahir = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    url_surat_potong_gaji = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bpjs_id", x => x.id);
                    table.ForeignKey(
                        name: "bpjs$bpjs_id_employee_foreign",
                        column: x => x.id_employee,
                        principalSchema: "indocement",
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "family_employee",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_employee = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    nama_pasangan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status_pasangan = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    jk_pasangan = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    tgl_lahir_pasangan = table.Column<DateOnly>(type: "date", nullable: false),
                    no_bpjs_pasangan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    pendidikan_pasangan = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telepon_pasangan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, defaultValueSql: "(NULL)"),
                    alamat_pasangan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    email_pasangan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    foto_pasangan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    nama_anak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tgl_lahir_anak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_anak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jk_anak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    no_bpjs_anak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pendidikan_anak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto_anak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nama_ayah = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status_ayah = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    jk_ayah = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    no_bpjs_ayah = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tgl_lahir_ayah = table.Column<DateOnly>(type: "date", nullable: false),
                    pendidikan_ayah = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telepon_ayah = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, defaultValueSql: "(NULL)"),
                    alamat_ayah = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    email_ayah = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    foto_ayah = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    nama_ibu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status_ibu = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    jk_ibu = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    no_bpjs_ibu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tgl_lahir_ibu = table.Column<DateOnly>(type: "date", nullable: false),
                    pendidikan_ibu = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telepon_ibu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, defaultValueSql: "(NULL)"),
                    alamat_ibu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    email_ibu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    foto_ibu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    nama_ayah_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status_ayah_mertua = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    jk_ayah_mertua = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    no_bpjs_ayah_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tgl_lahir_ayah_mertua = table.Column<DateOnly>(type: "date", nullable: false),
                    pendidikan_ayah_mertua = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telepon_ayah_mertua = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, defaultValueSql: "(NULL)"),
                    alamat_ayah_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    email_ayah_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    foto_ayah_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    nama_ibu_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status_ibu_mertua = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    jk_ibu_mertua = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    no_bpjs_ibu_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tgl_lahir_ibu_mertua = table.Column<DateOnly>(type: "date", nullable: false),
                    pendidikan_ibu_mertua = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telepon_ibu_mertua = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, defaultValueSql: "(NULL)"),
                    alamat_ibu_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    email_ibu_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    foto_ibu_mertua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_family_employee_id", x => x.id);
                    table.ForeignKey(
                        name: "family_employee$family_employee_id_employee_foreign",
                        column: x => x.id_employee,
                        principalSchema: "indocement",
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "id_card",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_employee = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    tgl_pengajuan = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    status_pengajuan = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    url_card_rusak = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    url_surat_kehilangan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_id_card_id", x => x.id);
                    table.ForeignKey(
                        name: "id_card$id_card_id_employee_foreign",
                        column: x => x.id_employee,
                        principalSchema: "indocement",
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "keluhan",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_employee = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    tgl_keluhan = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    keluhan = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "(NULL)"),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keluhan_id", x => x.id);
                    table.ForeignKey(
                        name: "keluhan$keluhan_id_employee_foreign",
                        column: x => x.id_employee,
                        principalSchema: "indocement",
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "konsultasi",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_employee = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    tgl_konsultasi = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    konsultasi = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "(NULL)"),
                    id_karyawan = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_konsultasi_id", x => x.id);
                    table.ForeignKey(
                        name: "konsultasi$konsultasi_id_employee_foreign",
                        column: x => x.id_employee,
                        principalSchema: "indocement",
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "indocement",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_employee = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email_verified_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    remember_token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "(NULL)"),
                    role = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_id", x => x.id);
                    table.ForeignKey(
                        name: "users$users_id_employee_foreign",
                        column: x => x.id_employee,
                        principalSchema: "indocement",
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "bpjs_id_employee_foreign",
                schema: "indocement",
                table: "bpjs",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "departement_id_plant_division_foreign",
                schema: "indocement",
                table: "departement",
                column: "id_plant_division");

            migrationBuilder.CreateIndex(
                name: "departement$departement_nama_departement_unique",
                schema: "indocement",
                table: "departement",
                column: "nama_departement",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "employee_id_esl_foreign",
                schema: "indocement",
                table: "employee",
                column: "id_esl");

            migrationBuilder.CreateIndex(
                name: "employee_id_section_foreign",
                schema: "indocement",
                table: "employee",
                column: "id_section");

            migrationBuilder.CreateIndex(
                name: "employee$employee_email_unique",
                schema: "indocement",
                table: "employee",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "employee$employee_employee_no_unique",
                schema: "indocement",
                table: "employee",
                column: "employee_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "failed_jobs$failed_jobs_uuid_unique",
                schema: "indocement",
                table: "failed_jobs",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "family_employee_id_employee_foreign",
                schema: "indocement",
                table: "family_employee",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "family_employee$family_employee_email_ayah_mertua_unique",
                schema: "indocement",
                table: "family_employee",
                column: "email_ayah_mertua",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "family_employee$family_employee_email_ayah_unique",
                schema: "indocement",
                table: "family_employee",
                column: "email_ayah",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "family_employee$family_employee_email_ibu_mertua_unique",
                schema: "indocement",
                table: "family_employee",
                column: "email_ibu_mertua",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "family_employee$family_employee_email_ibu_unique",
                schema: "indocement",
                table: "family_employee",
                column: "email_ibu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "family_employee$family_employee_email_pasangan_unique",
                schema: "indocement",
                table: "family_employee",
                column: "email_pasangan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_card_id_employee_foreign",
                schema: "indocement",
                table: "id_card",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "jobs_queue_index",
                schema: "indocement",
                table: "jobs",
                column: "queue");

            migrationBuilder.CreateIndex(
                name: "keluhan_id_employee_foreign",
                schema: "indocement",
                table: "keluhan",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "konsultasi_id_employee_foreign",
                schema: "indocement",
                table: "konsultasi",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "plant_division_id_unit_foreign",
                schema: "indocement",
                table: "plant_division",
                column: "id_unit");

            migrationBuilder.CreateIndex(
                name: "plant_division$plant_division_nama_plant_division_unique",
                schema: "indocement",
                table: "plant_division",
                column: "nama_plant_division",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "section_id_departement_foreign",
                schema: "indocement",
                table: "section",
                column: "id_departement");

            migrationBuilder.CreateIndex(
                name: "section$section_nama_section_unique",
                schema: "indocement",
                table: "section",
                column: "nama_section",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "sessions_last_activity_index",
                schema: "indocement",
                table: "sessions",
                column: "last_activity");

            migrationBuilder.CreateIndex(
                name: "sessions_user_id_index",
                schema: "indocement",
                table: "sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "unit$unit_nama_unit_unique",
                schema: "indocement",
                table: "unit",
                column: "nama_unit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_id_employee_foreign",
                schema: "indocement",
                table: "users",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "users$users_email_unique",
                schema: "indocement",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bpjs",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "cache",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "cache_locks",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "failed_jobs",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "family_employee",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "id_card",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "job_batches",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "jobs",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "keluhan",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "konsultasi",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "migrations",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "password_reset_tokens",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "sessions",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "users",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "employee",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "esl",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "section",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "departement",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "plant_division",
                schema: "indocement");

            migrationBuilder.DropTable(
                name: "unit",
                schema: "indocement");
        }
    }
}
