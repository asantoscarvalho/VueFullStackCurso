<template>
  <div >
    <titulo :texto="professorid != undefined ? 'Professor: ' + professor.nome : 'Todos os Alunos'" />
    <br>
    <div>
    <input type="text" placeholder="Nome do Aluno" v-model="nome" v-on:keyup.enter="addAluno()"> 
    <button class="btn btninput" @click="addAluno()">Adicionar</button>
    </div>
    <br>
    <table border="1px">
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno,index) in alunos" :key="index" >
          <td>{{aluno.id}}</td>
          <router-link :to="`/alunodetalhe/${aluno.id}`" tag="td" style="cursor: pointer"> {{aluno.nome}} {{aluno.sobreNome}}  </router-link>
          <td><button class="btn" @click="remover(aluno)">Remover</button></td>
        </tr>
      </tbody>
      <tfoot v-if="!alunos.length">
        <tr>
          <td colspan="3" style="text-align: center;"><b>Nenhum aluno cadastrado</b></td>
        </tr> 
      </tfoot>
    </table>
  </div>
</template>

<script>
import titulo from '../_share/Titulo.vue'

export default {
  components:{ titulo
  },
  data() {
    return {
      titulo: 'Aluno',
      professorid: this.$route.params.prof_id,
      nome: "",
      alunos:[],
      professor:{}
    }
  },
  created(){
    if (this.professorid)
    {
    this.$http
    .get(`http://localhost:5000/api/alunos/ByProfessor/${this.professorid}`)
    .then(res => res.json())
    .then(alunos => this.alunos = alunos)
    }
    else{
        this.$http
    .get('http://localhost:5000/api/alunos')
    .then(res => res.json())
    .then(alunos => this.alunos = alunos)
    }

      this.carregarProfessores();
  },
  props: {
    
  },
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobreNome: "",
      }
    this.$http
      .post('http://localhost:5000/api/alunos',_aluno)
      .then(res => res.json())
      .then(alunoRetornado => {this.alunos.push(alunoRetornado);
      this.nome = '';
      }
      );
    },
    remover(aluno){

      this.$http
      .delete(`http://localhost:5000/api/alunos/${aluno.id}`)
      .then(() => {

      let indice = this.alunos.indexOf(aluno);
      this.alunos.splice(indice,1);});
    },
    carregarProfessores(){
          if (this.professorid)
          {
            this.$http
            .get('http://localhost:5000/api/professores/'+ this.professorid)
            .then(res => res.json())
            .then(professor => this.professor = professor)
          }
          console.log(this.professor);

    }
  },
}
</script>


<style scoped>
 input{
   width: calc(100% - 195px);
   border:0;
   padding: 20px;
   font-size: 1.3em;
   color: #68f7f6;
   display: inline;
 }
 
 .btninput{
  width: 150px;
   border:0px;
   padding: 20px;
   font-size: 1.3em;
   display: inline;
   background-color: rgb(116,115, 115);
 }

</style>
