# 🎯 Aim Trainer — Simulador de Pontaria

O **Aim Trainer** é uma aplicação desktop desenvolvida em **C# Windows Forms** com integração a **SQL Server**, criada no âmbito da disciplina de Programação (Curso TGPSI). O sistema simula o treino de precisão para atletas de eSports, permitindo a gestão de perfis locais, gravação de recordes e tabelas de liderança global (Rankings) em tempo real.

---

## 🚀 Funcionalidades

- **🔒 Autenticação:** Sistema de login/registo seguro com isolamento de pontuações por utilizador.
- **🎯 5 Modos de Jogo:**
  - **GridShot:** Velocidade e ritmo com alvos em grelha média.
  - **SixShot:** Micro-precisão extrema com alvos reduzidos.
  - **MicroGridShot:** Pequenos ajustes finos de sensibilidade.
  - **SpiderShot:** Disparo periférico rápido com retorno obrigatório ao centro.
  - **StrafeTrack:** Rastreio contínuo de alvos em movimento horizontal.
- **🏆 Rankings Competitivos:**
  - Extração nativa do **Top 10** geral de cada exercício.
  - Destaque automático para o **Campeão (#1)** com o ícone `👑 @Username` e score máximo.
  - Interface moderna totalmente personalizada em **Dark Theme**.

---

## 🛠️ Tecnologias

- **Linguagem:** C# (.NET Framework)
- **Interface:** Windows Forms (Customizado dinamicamente via código)
- **Base de Dados:** Microsoft SQL Server (Instância `(localdb)\MSSQLLocalDB`)
- **Comunicação:** ADO.NET (`Microsoft.Data.SqlClient`) com queries parametrizadas.

---

## 💾 Tabelas da Base de Dados (`AimLabsDB`)

1. **`dbo.Users`**: Credenciais dos jogadores (`ID_User`, `Username`, `Password`).
2. **`dbo.Exercicios`**: Registo estático das modalidades (*GridShot*, *SixShot*, etc.).
3. **`dbo.Rankings`**: Histórico relacional que vincula o ID do utilizador ao recorde obtido.

---

## 🔧 Instalação Rápida

1. **Clonar e Abrir:**
   ```bash
   git clone [https://github.com/teuUser/AimTrainer.git](https://github.com/teuUser/AimTrainer.git)
