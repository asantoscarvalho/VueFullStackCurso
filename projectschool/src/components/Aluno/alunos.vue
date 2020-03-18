<template>
  <div >
    <titulo texto="Aluno" />
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
          <td>{{aluno.Nome}} {{aluno.Sobrenome}} </td>
          <td><button class="btn" @click="remover(aluno)">Remover</button></td>
        </tr>
      </tbody>
      <tfoot v-if="!alunos.length">
         <b>Nenhum aluno cadastrado</b>
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
      nome: 'Alunos',
      alunos:[]
    }
  },
  created(){
    this.$http
    .get('http://localhost:3000/alunos')
    .then(res => res.json())
    .then(alunos => this.alunos = alunos)
  },
  props: {
    
  },
  methods: {
    addAluno() {
      let _aluno = {
        Nome: this.nome,
        Sobrenome: ""

      }
    this.$http
      .post('http://localhost:3000/alunos',_aluno)
      .then(res => res.json())
      .then(alunoRetornado => {this.alunos.push(alunoRetornado);
      this.nome = '';
      }
      );
    },
    remover(aluno){

      this.$http
      .delete(`http://localhost:3000/alunos/${aluno.id}`)
      .then(() => {

      let indice = this.alunos.indexOf(aluno);
      this.alunos.splice(indice,1);});
    }
  },
}
</script>


<style scoped>
 input{
   border:0;
   padding: 20px;
   font-size: 1.3em;
   color: #68f7f6;
   display: inline;
 }
 
 .btninput{
   border:0px;
   padding: 20px;
   font-size: 1.3em;
   display: inline;
   background-color: rgb(116,115, 115);
 }

</style>
