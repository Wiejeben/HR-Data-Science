import * as React from 'react';
import styled from 'styled-components';
import Population from "./services/Population";
import DNA from "./services/DNA";

const Wrapper = styled.div`
    margin: 0 auto;
    max-width: 1000px;
    display: flex;
    flex-direction: row;
    justify-content: space-between
`;

const Title = styled.h1``;

const Column = styled.section``;

interface IAppState {
    bestPhrase: string;
    population: DNA[];
    averageFitness: number;
    totalGenerations: number;
}

export default class App extends React.Component<any, IAppState> {
    protected targetPhrase: string = 'To be or not to be.';
    protected mutationRate: number = 0.01;
    protected maxPopulation: number = 200;
    protected population: Population;

    constructor(props: any) {
        super(props);
        this.evolve = this.evolve.bind(this);

        this.population = new Population(this.targetPhrase, this.mutationRate, this.maxPopulation);

        this.population.calcFitness();

        this.state = {
            bestPhrase: this.population.best().toString(),
            population: this.population.getPopulation(),
            averageFitness: this.population.averageFitness(),
            totalGenerations: 0,
        };
    }

    public evolve(): void {
        this.population.naturalSelection();
        this.population.generate();
        this.population.calcFitness();

        this.setState({
            bestPhrase: this.population.best().toString(),
            population: this.population.getPopulation(),
            averageFitness: this.population.averageFitness(),
            totalGenerations: this.population.getGeneration(),
        });

        if (this.population.best().toString() !== this.targetPhrase) {
            window.requestAnimationFrame(this.evolve)
        }
    }

    public render() {
        return (
            <Wrapper>
                <Column>
                    <Title>Target phrase: {this.targetPhrase}</Title>
                    <Title>Best phrase: {this.state.bestPhrase}</Title>

                    <div>
                        total generations: {this.state.totalGenerations}<br/>
                        average fitness: {(this.state.averageFitness * 100).toFixed(2)}%<br/>
                        total population: {this.maxPopulation}<br/>
                        mutation rate: {this.mutationRate}%<br/>
                        <button onClick={this.evolve}>Evolve</button>
                    </div>
                </Column>
                <Column>
                    <ul>
                        {this.state.population.map((value, key) => <li key={key}>{value.toString()}</li>)}
                    </ul>
                </Column>
            </Wrapper>
        );
    }
}
