<template>
    <div v-if="!loading">
      <Titulo :texto="'Aluno: '+ aluno.nome" :btnVoltar="visualizar">
           <button class="btn btnEditar" @click="editar()" >Editar</button>
      </Titulo>
      <table>
          <tbody>
              <tr>
                  <td class="colPequeno">Matrícula</td>
                  <td>
                      <label> {{aluno.id}}</label>
                  </td>

              </tr>
              <tr>
                  <td class="colPequeno">Nome</td>
                  <td>
                      <label v-if="visualizar"> {{aluno.nome}}</label>
                      <input v-else type="text" v-model="aluno.nome">
                  </td>
              </tr>
              <tr>
                  <td class="colPequeno">Sobrenome</td>
                  <td>
                      <label v-if="visualizar" > {{aluno.sobreNome}}</label>
                      <input v-else type="text" v-model="aluno.sobreNome">
                  </td>
              </tr>
              <tr>
                  <td class="colPequeno">Data de Nascimento</td>
                  <td>
                      <label v-if="visualizar" > {{aluno.dataNascimento}}</label>
                      <input v-else type="text" v-model="aluno.dataNascimento">
                  </td>
              </tr>
              <tr>
                  <td class="colPequeno">Professor</td>
                  <td>
                      <label v-if="visualizar" > {{aluno.professor.nome}}</label>
                      <select v-else v-model="aluno.professorId" >
                          <option v-for="(professor,index) in Professores" :key="index" v-bind:value="professor.id">
                              {{ professor.nome }}
                          </option>
                      </select>
                  </td>
              </tr>
          </tbody>
      </table>
      <div  style="margin-top: 10px">
          <div v-if="!visualizar">
             <button class="btn btnSalvar" @click="salvar()">Salvar</button>
             <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
          </div>
      </div>

    </div>
    
</template>

<script>
    import Titulo from '../_share/Titulo'
    export default {
        components: {
            Titulo
        },
        data() {
            return {
                Professores:[],
                aluno: {},
                alunoid: this.$route.params.id,
                visualizar : true,
                loading : true
            }
        },
        created(){

            this.CarregarProfessor();

        },
        methods:{
            editar(){
                this.visualizar = !this.visualizar;
            },
            cancelar(){
                this.visualizar = true;
            },
            salvar(){
                

                let _alunoEditar  = {
                    id : this.aluno.id,
                    nome: this.aluno.nome,
                    sobreNome: this.aluno.sobreNome,
                    dataNascimento: this.aluno.dataNascimento,
                    professorId : this.aluno.professorId
                }

                

                this.$http.put(`http://localhost:5000/api/alunos/${_alunoEditar.id}`, _alunoEditar)            
                .then(res => res.json())
                .then(aluno => this.aluno = aluno);
                
                this.visualizar = true;
            },
            CarregarProfessor(){
                
            this.$http
            .get('http://localhost:5000/api/professores')
            .then(res => res.json())
            .then(
                professores => {
                    this.Professores = professores;
                    this.CarregarAluno();
                    }
            );
            },
            CarregarAluno(){
                 this.$http
                .get('http://localhost:5000/api/alunos/'+ this.alunoid)
                .then(res => res.json())
                .then(
                    aluno => {
                        this.aluno = aluno;
                        this.loading = false;
                        }
                    );
            }

        }
    }
</script>

<style scoped>
.btnEditar{
      float:right;
      background-color: rgb(76, 186, 249);
}
.btnSalvar{
      float:right;
      background-color: rgb(76, 196, 68);
}
.btnCancelar{
      float:left;
      background-color: rgb(249, 186, 92);
}
 .colPequeno{
     width:20%;
     text-align: right;
     background: rgb(125,217,245);
     font-weight: bold;
 }
 input,select{
     margin:0;
     padding:5px 10px;
     font-size:0.9em;
     border: 1px solid silver;
     border-radius: 5px;
     font-family: Montserrat;
     background-color: rgb(245, 245, 245);
     width: 95%;
 }
 select{
     height: 38px;
     width: 100%;
 }
</style>